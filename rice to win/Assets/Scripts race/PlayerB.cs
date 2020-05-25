using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerB : MonoBehaviour
{
    public Controls control;
    public float speed = 3f;
    private bool isKilled = false;

    void Update()
    {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);

        float hor = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(hor, 0, 0);

        transform.Translate(dir.normalized * Time.deltaTime * speed);

        float ver = Input.GetAxisRaw("Vertical");
        Vector3 dir1 = new Vector3(0, 0, ver);

        transform.Translate(dir1.normalized * Time.deltaTime * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            isKilled = false;
            StartCoroutine("Die"); //Запустить процесс умирания
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin") //Если столкновение с монетой
        {
            if (control != null) //Если столкнулась машина игрока
            {
                control.scores += 100f; //Добавить 100 очков
                Destroy(other.gameObject);
            }
        }

    }
    IEnumerator Die() //Процесс умирания
    {
        string path = "highscore"; //Путь к файлу, в котором сохраняется высший результат
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            byte[] bytes = new byte[Convert.ToInt32(fs.Length)];

            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

            string high = Encoding.UTF8.GetString(bytes);

            float highScore = 0f;

            try
            {
                highScore = Convert.ToSingle(high);
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }

            if (highScore < Math.Floor(control.scores))
            {
                byte[] newScores = Encoding.UTF8.GetBytes(Math.Floor(control.scores).ToString());

                fs.Write(newScores, 0, newScores.Length);
            }
        }

        yield return new WaitForSeconds(0f); //Подождать 2 секунды
        SceneManager.LoadScene("Menu"); //Перейти в меню
    }
}
