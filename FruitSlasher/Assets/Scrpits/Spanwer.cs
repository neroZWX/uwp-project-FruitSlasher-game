using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour
{

    public GameObject[] fruits;
    public GameObject Bomb;
    
    public AudioSource audioSource ;
    float spawnTime = 2f;
    bool isPlaying = true;

    void Update()
    {
        if (!isPlaying) {//如果为flase的话   就不会运行以下程序
            return;
        }  
            spawnTime -= Time.deltaTime;
            if (0 >= spawnTime)
            {  
            //随机产生多个水果
            int fruitCount = Random.Range(1, 5);
            for (int i = 0; i < fruitCount; i++) ;
                onSpawn(true);//召唤水果
                spawnTime = 3f;//归零计时器
                //随机产生炸弹
            int bombNum = Random.Range(0, 100);
            if (bombNum > 70) {
                onSpawn(false);
            }
            spawnTime = 3f;//归零计时器
        }
        }
    private int tmpZ = 0;
    private void onSpawn(bool isFruit) {//检测是否为水果
        this.audioSource.Play();
        float x = Random.Range(-8.4f, 8.4f);
        float y = transform.position.y;
        //是水果不在同一平面上 那么就不会发生碰撞
        float z = tmpZ;
        tmpZ = tmpZ - 2;
        if (tmpZ <= -10)
            tmpZ = 0;
        //实例化水果
        int fruitIndex = Random.Range(0, fruits.Length);
        GameObject go;
        if(isFruit)
         go = Instantiate<GameObject>(fruits[fruitIndex], new Vector3(x, y, z), Random.rotation);
        else 
         go = Instantiate<GameObject>(Bomb, new Vector3(x, y, z), Random.rotation);
        //定义水果的速度
        Vector3 velocity = new Vector3(-x * Random.Range(0.2f, 0.8f), -Physics.gravity.y * Random.Range(1.1f, 1.5f), 0);

        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;
     }
    //物体碰撞到spanwer Collider时销毁
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }

}