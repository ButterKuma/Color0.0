using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement {
    public int ID;
    public string Name;
    public int Level;
    public int Health;
    public int Damage;
    public int Defence;
    public int Total_EXP;
    public int P_EXP;
    public int Money;
    public string S_pos; //마지막 저장 위치 0 = x, 1 = y, 2 = z


    public PlayerManagement(int id, string name, int level, int health, int damage, int defence, int tExp, int pExp, int money,string sPos) {
       ID =id;
        Name =name;
        Level=level;
        Health=health;
        Damage=damage;
        Defence=defence;
        Total_EXP=tExp;
        P_EXP=pExp;
        Money=money;
        S_pos=sPos; //마지막 저장 위치 0 = x, 1 = y, 2 = z
}
}
