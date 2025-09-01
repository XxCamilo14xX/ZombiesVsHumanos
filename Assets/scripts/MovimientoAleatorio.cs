using UnityEngine;

public class ZombieIA : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        
        GameObject humano = GameObject.FindWithTag("Humano");
        if (humano != null)
        {
           
            Vector2 direccion = (humano.transform.position - transform.position).normalized;
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}

