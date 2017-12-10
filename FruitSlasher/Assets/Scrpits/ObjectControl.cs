using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour {
    public GameObject hafFruit;
    public GameObject Splash;
    public GameObject SplashFlat;
    public AudioClip  ac;
    private bool dead = false;
    //被切的时候调用
    public void OnCut() {
        //生成被切割的水果
        for (int i = 0; i < 2; i++) {
            //防止重复调用
            if (dead)
                return;
            if (gameObject.name.Contains("Bomb")) {
                Instantiate(Splash, transform.position, Quaternion.identity);
                UIScore.Instance.Remove(1000);

            }
            else {//下面是水果操作
                GameObject go = Instantiate<GameObject>(hafFruit, transform.position, Random.rotation);//被切的时候 半个水果随机生成位置
                go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, ForceMode.Impulse);//设置水果的被切分开时候的力量
                UIScore.Instance.Add(100);
            }
            //生成特效
            Instantiate(Splash, transform.position, Quaternion.identity);
            Instantiate(SplashFlat, transform.position, Quaternion.identity);

        }
        AudioSource.PlayClipAtPoint(ac,transform.position);
        
        Destroy(gameObject);
        dead = true;
    }
}
