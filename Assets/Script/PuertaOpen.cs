using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaOpen : MonoBehaviour
{
    public bool puertaAbierta = false;
    Vector3 posCerrado;
    Vector3 posAbierta;
    float speed = 10f;
    // Start is called before the first frame update

    void Awake(){
        posCerrado = transform.position;
        posAbierta = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z );
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
