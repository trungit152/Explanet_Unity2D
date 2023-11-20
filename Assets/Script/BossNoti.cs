using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNoti : MonoBehaviour
{
    [SerializeField] private Text bossNotiText;
    private Animator anim;
    public static BossNoti Instance;
    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void NoWeaponNoti()
    {
        bossNotiText.text = "You need a weapon to defeat the Boss\n(What about Banana?)";

        anim.SetTrigger("New Trigger");
    }
}
