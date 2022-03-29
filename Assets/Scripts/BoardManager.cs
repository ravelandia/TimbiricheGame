using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public static BoardManager Instance;
    public int Width = 4;
    public int Height = 4;
    public Point PointPrefab;
    public Line LinePrefab;
    private Point PuntoAnteriorp1;
    private Point PuntoActualp1;

    private int cont;


    

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GenerateBoard();
        cont = 2;
        
    }

    private async void GenerateBoard()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                var p = new Vector2(i, j);
                Instantiate(PointPrefab, p, Quaternion.identity);
            }

        }
        var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    

    public void SetPoint(Point p)
    {
        GameManager.Instance.SwitchPlayer();
        cont = cont - 1;
        if (cont == 0)
        {
            PuntoActualp1 = p;
            cont = 2;
            var line = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
            //ver que punto tiene un componente Y mayor que el otro
            //linea creada en el eje X
            if ((PuntoActualp1.GetComponent<Transform>().position.y - PuntoAnteriorp1.GetComponent<Transform>().position.y) == 1)
            {
                //mueve la linea a puntoanterior
                line.transform.position = PuntoAnteriorp1.GetComponent<Transform>().position;

            }
            else if ((PuntoActualp1.GetComponent<Transform>().position.y - PuntoAnteriorp1.GetComponent<Transform>().position.y) == -1)
            {
                //mueve la linea a puntoactual
                line.transform.position = PuntoActualp1.GetComponent<Transform>().position;
            }
            else
            {
                Destroy(line);
            }
            //Linea Creada en el eje Y
            if ((PuntoActualp1.GetComponent<Transform>().position.x - PuntoAnteriorp1.GetComponent<Transform>().position.x) == 1)
            {
                //mueve la linea a puntoanterior
                line.transform.position = PuntoAnteriorp1.GetComponent<Transform>().position;
                //rota la linea 270 grados
                line.transform.Rotate(0, 0, 270);
            }
            else if ((PuntoActualp1.GetComponent<Transform>().position.x - PuntoAnteriorp1.GetComponent<Transform>().position.x) == -1)
            {
                //mueve la linea a puntoactual
                line.transform.position = PuntoActualp1.GetComponent<Transform>().position;
                line.transform.Rotate(0, 0, 270);

            }
            else
            {
                Destroy(line);
            }
            if (Colisiones)
            {
                Debug.Log("Colision");
            }
            
                     
            
            
        }
        else
        {
                PuntoAnteriorp1 = p;
        }    

    }


    //checkea que la linea no colisiona con nada
    
}






