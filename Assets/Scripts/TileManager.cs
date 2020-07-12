using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Object[] yolPrefablari;
    public float zSpawn = 0;
    public float yolUzunlugu = 7.6f;
    public List<GameObject> aktifYollar;
    public Transform playerPos;

    void Start()
    {
        yolPrefablari = Resources.LoadAll("Tiles", typeof(GameObject));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
            aktifYollar.Add(YolOlustur(0));
        
    }

    private void Update()
    {
        if (aktifYollar.Count < 7)
            aktifYollar.Add(YolOlustur(Random.Range(0, yolPrefablari.Length)));
        if (playerPos.position.z -5 > zSpawn - (aktifYollar.Count * yolUzunlugu))
            DeleteTile();
    }

    public GameObject YolOlustur(int yolIndex)
    {
        GameObject sa = (GameObject)Instantiate(yolPrefablari[yolIndex], transform.forward * zSpawn, transform.rotation); 
        zSpawn += yolUzunlugu;
        return sa;
    }

    private void DeleteTile()
    {
        Destroy(aktifYollar[0]);
        aktifYollar.RemoveAt(0);
    }




}
