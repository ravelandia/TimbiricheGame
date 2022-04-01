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

    public LayerMask linea;

    //Intento de que la linea se valida o no
    public Counter CounterPrefab;

    private void Awake()
    {
        Instance = this;
        // Intaciar el CounterPrefab

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
        //no tocar GameManager.Instance.SwitchPlayer();
        GameManager.Instance.SwitchPlayer();
        Debug.Log(GameManager.Instance.GetGameState);
        var Actualplayer=GameManager.Instance.GetGameState;
        cont = cont - 1;

        if (cont == 0)
        {
            PuntoActualp1 = p;
            cont = 2;
            var line = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
            //Insntacia Counter 
            var counter = Instantiate(CounterPrefab, Vector3.zero, Quaternion.identity);
            var counter2 = Instantiate(CounterPrefab, Vector3.zero, Quaternion.identity);
            //ver que punto tiene un componente Y mayor que el otro
            //linea creada en el eje X
            var pointC = counter.GetComponentsInChildren<CircleCollider2D>();
            
            bool c1=false;
            bool c2=false;
            bool c3=false;
            bool c4=false;
            bool c5=false;
            bool c6=false;
            var pointCC=counter2.GetComponentsInChildren<CircleCollider2D>();
            float Y=PuntoActualp1.GetComponent<Transform>().position.y - PuntoAnteriorp1.GetComponent<Transform>().position.y;
            float X=PuntoActualp1.GetComponent<Transform>().position.x - PuntoAnteriorp1.GetComponent<Transform>().position.x;
            if (Y == 1 && X==0)
            {
                //mueve la linea a puntoanterior
                line.transform.position = PuntoAnteriorp1.GetComponent<Transform>().position + new Vector3(0, 0.5f, 0);
                //mmueve counter a line
                counter.transform.position = line.GetComponent<Transform>().position + new Vector3(0.5f, 0, 0);
                c1=Physics2D.OverlapCircle(pointC[1].transform.position, 0.1f, linea);
                c2=Physics2D.OverlapCircle(pointC[2].transform.position, 0.1f, linea);
                c3 = Physics2D.OverlapCircle(pointC[3].transform.position, 0.1f, linea);
                //AddPoint(c1, c2, c3);
                counter2.transform.position = counter.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
                //c4 = Physics2D.OverlapCircle(pointCC[1].transform.position, 0.1f, linea);
                c4=true;
                c5 = Physics2D.OverlapCircle(pointCC[2].transform.position, 0.1f, linea);
                c6 = Physics2D.OverlapCircle(pointCC[3].transform.position, 0.1f, linea);

                
            }
            else if (Y == -1 & X==0)
            {
                //mueve la linea a puntoactual
                line.transform.position = PuntoActualp1.GetComponent<Transform>().position + new Vector3(0, 0.5f, 0);
                //mmueve counter a line
                counter.transform.position = line.GetComponent<Transform>().position + new Vector3(0.5f, 0, 0);
                c1=Physics2D.OverlapCircle(pointC[1].transform.position, 0.1f, linea);
                c2=Physics2D.OverlapCircle(pointC[2].transform.position, 0.1f, linea);
                c3 = Physics2D.OverlapCircle(pointC[3].transform.position, 0.1f, linea);
                

                counter2.transform.position = counter.GetComponent<Transform>().position + new Vector3(-0.6f, 0, 0);
                //c4 = Physics2D.OverlapCircle(pointCC[0].transform.position, 0.1f, linea);
                c4=true;
                c5 = Physics2D.OverlapCircle(pointCC[2].transform.position, 0.1f, linea);
                c6 = Physics2D.OverlapCircle(pointCC[3].transform.position, 0.1f, linea);

                //Debug.Log(c1+" "+c2+" "+c3+" ==> " +c4 + " " + c5 + " " + c6);

            }else if (X == 1 & Y==0)
            {
                //mueve la linea a puntoanterior
                line.transform.position = PuntoAnteriorp1.GetComponent<Transform>().position + new Vector3(0.5f, 0, 0);
                //rota la linea 270 grados
                line.transform.Rotate(0, 0, 90);
                //mmueve counter a line
                counter.transform.position = line.GetComponent<Transform>().position + new Vector3(0, 0.5f, 0);
                c1=Physics2D.OverlapCircle(pointC[1].transform.position, 0.1f, linea);
                c2=Physics2D.OverlapCircle(pointC[0].transform.position, 0.1f, linea);
                c3 = Physics2D.OverlapCircle(pointC[3].transform.position, 0.1f, linea);
                counter2.transform.position = line.GetComponent<Transform>().position + new Vector3(0, -0.5f, 0);
                c4 = Physics2D.OverlapCircle(pointCC[0].transform.position, 0.1f, linea);
                c5 = Physics2D.OverlapCircle(pointCC[2].transform.position, 0.1f, linea);
                c6 = Physics2D.OverlapCircle(pointCC[1].transform.position, 0.1f, linea);
            }
            else if (X == -1 & Y==0)
            {
                //mueve la linea a puntoactual
                line.transform.position = PuntoActualp1.GetComponent<Transform>().position + new Vector3(0.5f, 0, 0);
                line.transform.Rotate(0, 0, 90);
                //mmueve counter a line
                counter.transform.position = line.GetComponent<Transform>().position + new Vector3(0, 0.5f, 1);
                c1=Physics2D.OverlapCircle(pointC[1].transform.position, 0.1f, linea);
                c2=Physics2D.OverlapCircle(pointC[0].transform.position, 0.1f, linea);
                c3 = Physics2D.OverlapCircle(pointC[3].transform.position, 0.1f, linea);

                counter2.transform.position = line.GetComponent<Transform>().position + new Vector3(0, -0.5f, 1);
                c4 = Physics2D.OverlapCircle(pointCC[0].transform.position, 0.1f, linea);
                c5 = Physics2D.OverlapCircle(pointCC[2].transform.position, 0.1f, linea);
                c6 = Physics2D.OverlapCircle(pointCC[1].transform.position, 0.1f, linea);

            }
            else
            {
                Destroy(line.gameObject);
                Debug.Log("No se puede dibujar");
                GameManager.Instance.GetInvalidLine(Actualplayer);
            }
            if (c1 && c2 && c3)
            {
                GameManager.Instance.GetPuntuation(Actualplayer,1);
            }
            if (c6 && c4 && c5)
            {
                GameManager.Instance.GetPuntuation(Actualplayer,1);
            }
            Destroy(counter.gameObject);
            Destroy(counter2.gameObject);

        }
        else
        {
            PuntoAnteriorp1 = p;
        }

    }





}






