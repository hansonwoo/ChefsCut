using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarConfig : MonoBehaviour
{
    [SerializeField]private Sprite fullHeartSprite;
    [SerializeField]private Sprite halfHeartSprite;
    [SerializeField]private Sprite noHeartSprite;
    [SerializeField]private GameObject[] heartArray = new GameObject[3];
    [SerializeField]private int health = 3;
    public void updateHearts(int health) 
    {   
        if (health > heartArray.Length * 2)
        {
            health = heartArray.Length * 2;
        }
        int maxHealth = heartArray.Length;
        int fullHearts = health / 2;
        int halfHearts = health % 2;
        int emptyHearts = maxHealth - fullHearts - halfHearts;
        int index = 0;
        while (fullHearts != 0)
        {
            SpriteRenderer spriteReference = updateSpriteReferences(index);
            spriteReference.sprite = fullHeartSprite;
            index += 1;
            fullHearts -= 1;
        }
        if (halfHearts > 0)
        {
            SpriteRenderer spriteReference = updateSpriteReferences(index);
            spriteReference.sprite = halfHeartSprite;
            index += 1;
        }
        while (emptyHearts != 0)
        {
            SpriteRenderer spriteReference = updateSpriteReferences(index);
            spriteReference.sprite = noHeartSprite;
            index += 1;
            emptyHearts -= 1;
        }
        
    }

    private SpriteRenderer updateSpriteReferences(int index)
    {
        SpriteRenderer heartRenderer = heartArray[index].GetComponent<SpriteRenderer>();
        return heartRenderer;
    }

    void Start()
    {
        updateHearts(health);
    }

    void Update()
    {
        
    }

    
    

}
