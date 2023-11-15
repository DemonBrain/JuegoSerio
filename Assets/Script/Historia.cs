using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{
    [SerializeField] private HistoriaTex historiaTex;
    private Text textElement;


    private void Awake()
    {
        textElement = transform.Find("Historia").GetComponent<Text>();

    }
    // Start is called before the first frame update
    void Start()
    {
        historiaTex.AddWriter(textElement, "Bienvenidos a la aventura de Kiwi y Nutria, dos amigos inseparables en una misión para salvar su hogar. Juntos emprenden un viaje a través de bosques, praderas y montañas en busca de semillas mágicas. Su mundo se ha vuelto gris y triste, los árboles se han secado y los animales han huido. Pero Kiwi y Nutria están decididos a devolver la vida y el color a su tierra plantando estas semillas especiales.\r\n\r\nAyuda a Kiwi y Nutria a restaurar su hogar combinando tu ingenio con el trabajo en equipo. Juntos podemos marcar la diferencia y devolver la belleza natural a este mundo que tanto necesita de nuestro cuidado.\r\n\r\n¡Es hora de salvar el bosque! ¿Estás listo?", .05f);
    }


}
