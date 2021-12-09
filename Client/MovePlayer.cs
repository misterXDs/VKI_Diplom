using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    public int speed;
    [SerializeField]
    Rigidbody playMov;
    float zaderzhkaW = 0, zaderzhkaS = 0, zaderzhkaD = 0, zaderzhkaA = 0;
    float Post_MoveW = 0, Post_MoveS = 0, Post_MoveD = 0, Post_MoveA = 0;
    float TempW = 0, TempS = 0, TempD = 0, TempA = 0;
    public float Zaderzhka;
    bool BoolMoveForward = false, BoolMoveBack = false, BoolMoveRight = false, BoolMoveLeft = false;
    float hodW = 0, hodS = 0, hodD = 0, hodA = 0;

    void Start()
    {
        player = transform;
        playMov = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Движение с задержкой вперед
        if ((BoolMoveForward == true) && (Input.GetKey(KeyCode.W) == false))
        {
            if(TempW < Zaderzhka)
            {
                TempW += Time.deltaTime;
            }
            else
            if (hodW < Post_MoveW)
            {
                player.position += player.forward * speed * Time.deltaTime;
                hodW += Time.deltaTime;
                print(hodW);
            }
            else { hodW = 0; BoolMoveForward = false; Post_MoveW = 0; TempW = 0; }
        }
        //Движение с задержкой назад
        if ((BoolMoveBack == true) && (Input.GetKey(KeyCode.S) == false))
        {
            if (TempS < Zaderzhka)
            {
                TempS += Time.deltaTime;
            }
            else
            if (hodS < Post_MoveS)
            {
                player.position -= player.forward * speed * Time.deltaTime;
                hodS += Time.deltaTime;
                print(hodS);
            }
            else { hodS = 0; BoolMoveBack = false; Post_MoveS = 0; TempS = 0; }
        }
        //Движение с задержкой вправо
        if ((BoolMoveRight == true) && (Input.GetKey(KeyCode.D) == false))
        {
            if (TempD < Zaderzhka)
            {
                TempD += Time.deltaTime;
            }
            else
            if (hodD < Post_MoveD)
            {
                player.position += player.right * speed * Time.deltaTime;
                hodD += Time.deltaTime;
                print(hodD);
            }
            else { hodD = 0; BoolMoveRight = false; Post_MoveD = 0; TempD = 0; }
        }
        //Движение с задержкой влево
        if ((BoolMoveLeft == true) && (Input.GetKey(KeyCode.A) == false))
        {
            if (TempA < Zaderzhka)
            {
                TempA += Time.deltaTime;
            }
            else
            if (hodA < Post_MoveA)
            {
                player.position -= player.right * speed * Time.deltaTime;
                hodA += Time.deltaTime;
                print(hodA);
            }
            else { hodA = 0; BoolMoveLeft = false; Post_MoveA = 0; TempA = 0; }
        }
        //Обнуление счетчика задержки вперед
        if (Input.GetKey(KeyCode.W) == false)
            zaderzhkaW = 0;
        //Обнуление счетчика задержки назад
        if (Input.GetKey(KeyCode.S) == false)
            zaderzhkaS = 0;
        //Обнуление счетчика задержки вправо
        if (Input.GetKey(KeyCode.D) == false)
            zaderzhkaD = 0;
        //Обнуление счетчика задержки влево
        if (Input.GetKey(KeyCode.A) == false)
            zaderzhkaA = 0;
        //Основное движение
       
            //Движение вперед
            if (Input.GetKey(KeyCode.W))
            {
            //Задержка
            if (zaderzhkaW < Zaderzhka)
            {
                zaderzhkaW += Time.deltaTime;
                Post_MoveW = zaderzhkaW;
                TempW = Post_MoveW;
                print(Post_MoveW);
                BoolMoveForward = true;
            }
            else
            {
                player.position += player.forward * speed * Time.deltaTime;
                
            }
            }
            //Движение назад
            if (Input.GetKey(KeyCode.S))
            {
            //Задержка
            if (zaderzhkaS < Zaderzhka)
            {
                zaderzhkaS += Time.deltaTime;
                Post_MoveS = zaderzhkaS;
                TempS = Post_MoveS;
                BoolMoveBack = true;
            }
            else
            {
                player.position -= player.forward * speed * Time.deltaTime;               
            }
            }
            //Движение вправо
            if (Input.GetKey(KeyCode.D))
            {
            //Задержка
            if (zaderzhkaD < Zaderzhka)
            {
                zaderzhkaD += Time.deltaTime;
                Post_MoveD = zaderzhkaD;
                TempD = Post_MoveD;
                BoolMoveRight = true;
            }
            else
            {
                player.position += player.right * speed * Time.deltaTime;              
            }
            }
            //Движение влево
            if (Input.GetKey(KeyCode.A))
            {
            //Задержка
            if (zaderzhkaA < Zaderzhka)
            {
                zaderzhkaA += Time.deltaTime;
                Post_MoveA = zaderzhkaA;
                TempA = Post_MoveA;
                BoolMoveLeft = true;
            }
            else
            {
                player.position -= player.right * speed * Time.deltaTime;             
            }
            }
        
    }
        
}
