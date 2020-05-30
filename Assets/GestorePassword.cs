using System.Collections.Generic;
using UnityEngine;

public class GestorePassword : MonoBehaviour {
    
    public static GestorePassword intance { get; private set; }
    [SerializeField] private List<PasswordData> passwordList;
    readonly Dictionary<PasswordID, PasswordData> passwordMap = new Dictionary<PasswordID, PasswordData>();
    private List<PasswordID> ids = new List<PasswordID>();
    private int currentIndex;
    private const string chiaveIndex = "chiaveIndex";

    private void Start() {
        foreach (var psw in passwordList){
            passwordMap.Add(psw.id, psw);
            ids.Add(psw.id);
        }

        //currentIndex = PlayerPrefs.GetInt(chiaveIndex, 0);
        currentIndex = 0;
    }

    private void Awake() {
        intance = this;
        DontDestroyOnLoad(this);
    }

    public PasswordData GetPasswordData(PasswordID passwordId) {
        return passwordMap[passwordId];
    }

    public PasswordID GetUnusedPasswordId() {
        var currentId = ids[currentIndex];
        currentIndex++;
        return currentId;
    }
}
