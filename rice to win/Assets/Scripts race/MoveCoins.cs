using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MoveCoins : MonoBehaviour
    {

        public float speed = 2f;

        void FixedUpdate()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y < -6)
                Destroy(gameObject);
        }

    }
