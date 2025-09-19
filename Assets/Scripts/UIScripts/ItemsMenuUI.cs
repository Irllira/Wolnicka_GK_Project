using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 <summary>
    This class is responsible for controling the player's inventory interface
 </summary>
 */
public class ItemsMenuUI : GeneralUI
{
    private ItemsManager playerInventory;

    private Transform itemSlotContainer;
    private Transform itemSlotTamplate;
    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTamplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(ItemsManager inventory)
    {
        this.playerInventory = inventory;
        RefreshInventory();
    }

    public void ShowInventory()
    {
        itemSlotContainer.gameObject.SetActive(true);

    }

    public void HideInventory()
    {
        itemSlotContainer.gameObject.SetActive(false);
    }
    private void RefreshInventory()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child != itemSlotTamplate)
                Destroy(child.gameObject);
        }
        
        int i = 0;
        int start = 0;
        float cellSize = 45f;
        int chosenItem = playerInventory.GetChosenItem();
        Image icon;
        Image frame;
        TextMeshProUGUI text;

        if(chosenItem>=4)
        {
            start = chosenItem - 3;
        }




        foreach (Item itemSlot in playerInventory.GetItemList())
        {
            if (i >= start)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTamplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);

                itemSlotRectTransform.anchoredPosition = new Vector2(0, -(i-start) * cellSize);              //position

                icon = itemSlotRectTransform.Find("Background").Find("Icon").GetComponent<Image>();             //icon
                icon.sprite = itemSlot.GetSprite();

                text = itemSlotRectTransform.Find("Background").Find("ItemName").GetComponent<TextMeshProUGUI>();   //text
                text.text = itemSlot.GetItemName();


                frame = itemSlotRectTransform.Find("Frame").GetComponent<Image>();                                 //currently chosen item
                if (chosenItem == i)
                {
                    frame.gameObject.SetActive(true);
                }
                else
                {

                    frame.gameObject.SetActive(false);
                }
            }
            i++;
            if (i == start + 4)
                return;
        }
    }
}
