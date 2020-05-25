using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinSound; //Звук монеты

    public void Delete() //Удаление монеты
	{
		var sound = Instantiate(coinSound, transform.position, transform.rotation); //Добавление звука монеты

		Destroy(sound, 2f); //Уничтожение звука через две секунды
		Destroy(gameObject); //Сама монета удалится сразу
	}
}
