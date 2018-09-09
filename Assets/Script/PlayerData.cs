using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player Data Struct Class
public class PlayerData
{

    private int ID;
    private string Name;
    private int Level;
    private int Health;
    private int Damage;
    private int Defence;
    private int Total_EXP;
    private int P_EXP;
    private int Money;
    private List<int> DoneQuest = new List<int>(); //진행 중 퀘스트
    private List<int> FinishQuest = new List<int>(); //완료한 퀘스트
    private List<int> Inventory = new List<int>(); //아이템 Inventory
    private List<int> S_Position = new List<int>(); //마지막 저장 위치 0 = x, 1 = y, 2 = z, 

    public PlayerData(string name, int id) //Strat
    {
        ID = id;
        Name = name;
        Level = 1;
        Health = 100;
        Damage = 10;
        Defence = 15;
        Total_EXP = 800;
        P_EXP = 0;
    }
    public PlayerData(int id) //Data Load
    {
        ID = id;
        Name = null;
        Level = 1;
        Health = 100;
        Damage = 10;
        Defence = 15;
        Total_EXP = 800;
        P_EXP = 0;
    }

    public PlayerData PlayerDataLoad() {


        return null;
    }
}
