using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance; // ���ο��� ����
    public static CharacterManager Instance // �ܺο��� ����
    {
        get
        {
            if (_instance == null) // CharacterManager ������Ʈ�� ��� �����ؼ� �־���
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }
    }

    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake() // �̱���
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
