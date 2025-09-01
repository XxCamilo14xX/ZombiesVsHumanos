using UnityEngine;
using System.Collections.Generic;

public class ZombieSimulationVisual : MonoBehaviour
{
    public int totalHumanos = 100;   
    public int zombies = 1;          
    private int dia = 0;

    public GameObject prefabHumano;  
    public GameObject prefabZombie;  
    private List<GameObject> humanos = new List<GameObject>();
    private List<GameObject> listaZombies = new List<GameObject>();

    void Start()
    {
        
        for (int i = 0; i < totalHumanos; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            GameObject h = Instantiate(prefabHumano, pos, Quaternion.identity);
            humanos.Add(h);
        }

       
        Vector2 posZombie = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        GameObject z = Instantiate(prefabZombie, posZombie, Quaternion.identity);
        listaZombies.Add(z);

        Debug.Log("Día 0: Humanos = " + totalHumanos + " | Zombies = " + zombies);

        InvokeRepeating("SimularDia", 2f, 2f); 
    }

    void SimularDia()
    {
        dia++;

       
        int nuevosZombies = zombies;  
        zombies *= 2;  

        int infectadosHoy = Mathf.Min(nuevosZombies, humanos.Count);

        
        for (int i = 0; i < infectadosHoy; i++)
        {
            if (humanos.Count > 0)
            {
                GameObject h = humanos[0];
                humanos.RemoveAt(0);

                
                Vector2 pos = h.transform.position;
                Destroy(h);
                GameObject z = Instantiate(prefabZombie, pos, Quaternion.identity);
                listaZombies.Add(z);
            }
        }

        Debug.Log("Día " + dia + ": Humanos = " + humanos.Count + " | Zombies = " + listaZombies.Count);

        if (humanos.Count <= 0)
        {
            Debug.Log("¡Todos fueron infectados al día " + dia + "!");
            CancelInvoke("SimularDia");
        }
    }
}

