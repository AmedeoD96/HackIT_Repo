using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PasswordData", menuName = "PasswordData", order = 0)]
public class PasswordData : ScriptableObject {
    public PasswordID id;
    public string password;
    public List<string> indizi = new List<string>();
    public List<Suggerimento> listaSuggerimenti = new List<Suggerimento>();
    public string spiegazione;
}

[Serializable]
public class Suggerimento {
    public string suggerimentTxt;
    public int costo;
}
