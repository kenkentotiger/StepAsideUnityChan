using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //ユニティちゃんの進んだ距離
    private float distance;
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //アイテムを生成したポジション
    private float insatantiatePosition;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        this.transform.position = new Vector3(0, this.transform.transform.position.y, this.unitychan.transform.position.z);

        //1.ユニティちゃんの進んだ距離を計測するプログラムを書く
        this.distance = this.unitychan.transform.position.z - insatantiatePosition;

        //生成位置を更新する
        //ユニティちゃんの進んだ距離15mごとにアイテムを生成する
        if (this.distance > 15)
        {
            this.insatantiatePosition = this.unitychan.transform.position.z;
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 10);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    //2.アイテムを生成させる位置をユニティちゃんの50m先にする
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 50);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 10);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        //2.アイテムを生成させる位置をユニティちゃんの50m先にする
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        //2.アイテムを生成させる位置をユニティちゃんの50m先にする
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                }
            }
        }
    }
}



//1.ユニティちゃんの進んだ距離を計測するプログラムを書く
//1-1.以前アイテムを生成した位置を保存しておく(50mおきにアイテムが生成）
//位置を保存するタイミングが重要になってくる。
//進んだ距離 = ユニティちゃんの位置 - 以前アイテムを生成した位置 

//2.if文のユニティちゃんの進んだ距離に応じて、アイテムを生成する
//1.アイテムを生成するタイミング（ユニティちゃんの進行に合わせて）
//2.アイテムを生成させる位置をユニティちゃんの50m先にする

