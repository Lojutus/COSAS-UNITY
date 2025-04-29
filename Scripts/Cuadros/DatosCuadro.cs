using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DatosCuadro : MonoBehaviour
{
    public int Valor_Numerico, Stack;
    [Range(0, 4)]
    public int Valor_Operacion;

    private int valor_Operacion = 0;
    private float timer = 0f;

    public TMP_Text Texto;
    private Rigidbody2D rb2D;

    public bool randomizer;
    [SerializeField] int valorMin, valorMax;

    private Ui ui;
    private Arrastrable arrastrable;
    public ObjectPool objectPool;

    void Start()
    {
        objectPool = GameObject.Find("ManagerPool").GetComponent<ObjectPool>();
        ui = GameObject.Find("Canvas").GetComponent<Ui>();
        rb2D = GetComponent<Rigidbody2D>();
        arrastrable = GetComponent<Arrastrable>();
    }

    void OnEnable()
    {
        if (ui != null)
        {
            valorMin = ui.Min;
            valorMax = ui.Max;
            Stack = ui.StackSpawn;
        }

        if (randomizer) Randomizer();

        valor_Operacion = Valor_Operacion;
        if (Valor_Operacion == 0)
        {
            modificarGravedad(0.3f);
        }
        else
        {
            ConfigurarOperacion();
        }
    }

    void OnDisable()
    {
        Randomizer();
        Valor_Numerico = 0;
    }

    void Update()
    {
        if (Valor_Operacion != 0 && Valor_Numerico != 0)
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                if (Valor_Numerico == 0)
                {
                    objectPool.ReturnObject(gameObject);
                }
                else
                {
                    Valor_Operacion = 0;
                }
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
        if (ui != null && transform.localScale.x > 5 && transform.localScale.y > 5){
            transform.localScale = new Vector2(1f, 1f);
        }
        ActualizarTextoYEscala();
        if (rb2D.linearVelocity.y < -10) //CONFIGURA LA VELOCIDAD MAXIMA
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, -10);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pared"))
        {
            if (Valor_Operacion != 0 && Valor_Numerico == 0)
            {
                Randomizer();
                objectPool.ReturnObject(gameObject);
            }
            else
            {
                Valor_Operacion = 0;
            }
        }
        else if (other.gameObject.CompareTag("Destruir"))
        {
            Valor_Numerico = 0;
            Randomizer();
            objectPool.ReturnObject(gameObject);
        }
        else if (other.gameObject.CompareTag("cubo") && Valor_Operacion != 0)
        {
            DatosCuadro Data_colision = other.gameObject.GetComponent<DatosCuadro>();
            if (Data_colision.Valor_Operacion == 0 && (Stack == Data_colision.Stack || Valor_Numerico == 0))
            {
                Operar(Data_colision.Valor_Numerico);
                Stack = Data_colision.Stack;
                objectPool.ReturnObject(other.gameObject);
            }
        }
    }

    void Operar(int Numero)
    {
        if (Valor_Operacion != 0) valor_Operacion = Valor_Operacion;

        if (Valor_Numerico != 0)
        {
            switch (valor_Operacion)
            {
                case 1:
                    ui.Points -= Numero;
                    break;
                case 2:
                    Valor_Numerico += Numero;
                    break;
                case 3:
                    Valor_Numerico = Mathf.Min(Valor_Numerico * Numero, ui.Almacenamiento);
                    break;
                case 4:
                    if (Numero != 0) Valor_Numerico /= Numero;
                    break;
            }

            ActualizarPuntaje();
        }
        else
        {
            Valor_Numerico = Numero;
        }
    }

    void ActualizarPuntaje()
    {
        if ((Stack - ui.Stack) == 1)
        {
            ui.newPoints += Valor_Numerico;
        }
        else if ((Stack - ui.Stack) == 0)
        {
            ui.Points += Valor_Numerico;
        }
        else if ((Stack - ui.Stack) == -1)
        {
            ui.Max = 1001;
            ui.moreNum();
        }
    }

    void Randomizer()
    {
        int i = Random.Range(0, 17);
        if (i > 8)
        {
            Valor_Operacion = 0;
            Valor_Numerico = Random.Range(valorMin, valorMax);
        }
        else
        {
            Valor_Operacion = i switch
            {
                0 or 1 => 1,
                > 2 and < 7 => 2,
                7 => 3,
                8 => 4,
                _ => Valor_Operacion
            };
        }
    }

    void modificarGravedad(float Gravedad)
    {
        if (rb2D != null) rb2D.gravityScale = Gravedad;
    }

    void ConfigurarOperacion()
    {
        switch (Valor_Operacion)
        {
            case 1:
                Texto.text = "-";
                break;
            case 2:
                Texto.text = "+";
                modificarGravedad(0.3f);
                break;
            case 3:
                Texto.text = "*";
                modificarGravedad(0.1f);
                break;
            case 4:
                Texto.text = "/";
                break;
        }
    }

    void ActualizarTextoYEscala()
    {
        if (ui != null && transform.localScale.x < 5 && transform.localScale.y < 5)

        {
            transform.localScale = new Vector2(1f + (Valor_Numerico / (1000f * ui.Space)), 1f + (Valor_Numerico / (1000f * ui.Space)));
        }
        else {
            transform.localScale = new Vector2(1f, 1f);
        }

        if (Valor_Operacion == 0)
        {
            if (Valor_Numerico <= 1000 && Stack == 0)
            {
                Texto.text = Valor_Numerico.ToString();
            }
            else if (Valor_Numerico > 1000)
            {
                while (Valor_Numerico >= 1000)
                {
                    Valor_Numerico /= 1000;
                }
                Stack++;
            }

            Texto.text = Valor_Numerico.ToString() + ObtenerSufijo(Stack);
        }
    }

    string ObtenerSufijo(int stack)
    {
        return stack switch
        {
            1 => "K",
            2 => "M",
            3 => "B",
            4 => "T",
            5 => "q",
            6 => "Q",
            7 => "S",
            8 => "O",
            9 => "N",
            10 => "d",
            11 => "D",
            12 => "E",
            _ => ""
        };
    }
}
