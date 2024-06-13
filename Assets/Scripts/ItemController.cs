using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemManager itemManager;
    private Animator animator;
    private int IdIsCollect;
    [SerializeField] bool unLockDoubleJump, unLockDash, unLockBallModeAndDropsBombs;
    //[SerializeField]private Transform tranformItem;
    [SerializeField] private float itemFadeDuration;
    private Collider2D col;

    private void Awake()
    {
        //tranformItem = GetComponent<Transform>();
        col = GetComponent<Collider2D>();
    }


    private void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        animator = GetComponent<Animator>();
        IdIsCollect = Animator.StringToHash("isCollect");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(col);
            animator.SetBool(IdIsCollect, true);
            animator.speed = itemFadeDuration;
            //tranformItem.localPosition = new Vector3(0, 2, 0); //No me esta funcionando
            if (unLockDoubleJump) itemManager.AddHeart();
            if (unLockDash) itemManager.AddCoinSpin();
            if (unLockBallModeAndDropsBombs) itemManager.AddCoinShine();
            Destroy(gameObject, (itemFadeDuration + 1));
            

        }
    }

   
}
