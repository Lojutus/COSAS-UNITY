using UnityEngine;

public class AnimatorController : MonoBehaviour
{
     public Animator animator; // Referencia al Animator

    void Start()
    {
        // Asegúrate de que el Animator no esté vacío
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        
    }
    public void ReproducirAnimacion1(string animacion){
        ReproducirAnimacion("Shake");
    }
    public void ReproducirAnimacion(string animacion)
    {
        animator.Play(animacion, -1, 0f); // Reproduce la animación directamente
        // O usa un trigger si tienes transiciones configuradas
        // animator.SetTrigger("MiTrigger");
        Debug.Log(animacion);
    }
}
