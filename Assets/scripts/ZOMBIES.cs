using UnityEngine;

public class ZombieSimulation : MonoBehaviour
{
    public int totalHumanos = 100;
    public int zombies = 1;
    private int dia = 0;
   

    void Start()
    {
        Debug.Log("Simulación de infección iniciada...");
        Debug.Log("Día 0: Humanos sanos = " + totalHumanos + " | Zombies = " + zombies);


        InvokeRepeating("SimularDia", 1f, 1f);
    }

    void SimularDia()
    {
        dia++;

        int nuevosZombies = zombies;
        zombies = zombies * 2;


        int infectadosHoy = Mathf.Min(nuevosZombies, totalHumanos);
        totalHumanos -= infectadosHoy;

        Debug.Log("Día " + dia + ": Humanos sanos = " + totalHumanos + " | Zombies = " + zombies);


        if (totalHumanos <= 0)
        {
            Debug.Log("¡Todos los humanos fueron infectados al día " + dia + "!");
            CancelInvoke("SimularDia");
        }
    }
    

}
