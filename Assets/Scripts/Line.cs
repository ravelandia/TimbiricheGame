using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject Inner;

    public bool State;


    public LayerMask Linea;
    public Transform pointer;
    private bool Colisiones;



    // Start is called before the first frame update
    void Start()
    {
        State=false;
        Colisiones=false;
    }

    // Update is called once per frame
    void Update()
    {
       Colisiones=Physics2D.OverlapCircle(pointer.position,0.1f,Linea);

    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "line")
        {
            this.State = true;
        }
    }

    //Envia el State
    public bool GetState()
    {
        return this.State;
    }

}
