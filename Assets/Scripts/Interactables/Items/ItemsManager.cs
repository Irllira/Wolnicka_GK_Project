using UnityEngine;
using System.Collections.Generic;

public class ItemsManager : MonoBehaviour
{
    private List<Item> itemList;
    private int chosenItem=0;


    public ItemsManager()
    {
        itemList = new List<Item>();

    }

   public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        foreach(Item it in itemList)
        {
            if(it.scriptableObject.itemName==item.scriptableObject.itemName)
            {
                itemList.Remove(it);
                return;
            }
        }
        
    }

    public List<Item> GetItemList()
    {
        return itemList; 
    }

    public int GetInventorySize()
    {
        int i = 0;
        foreach(Item item in itemList)
        {
            i++;
        }
        return i;
    }
    public bool CheckInventory(Item check)
    {
        foreach(Item item in itemList)
        {
            if (check.GetScriptable() == item.GetScriptable())
            {
                return true;
            }
        }
        return false;
    }
  

    public bool CheckInventory(string itemName)
    {
        foreach (Item item in itemList)
        {
            if (itemName == item.GetItemName())
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckChosenItem(Item check)
    {
        if (itemList[chosenItem] == check)
            return true;
        return false;
    }
    public bool CheckChosenItem(string itemName)
    {        
        if (itemList.Count>chosenItem && itemList[chosenItem].GetItemName() == itemName)
            return true;
        return false;
    }


    public int GetChosenItem()
    {
        return chosenItem;
    }

    public void SetChosenItem(int i)
    {
        chosenItem = i;
    }
    public void ChangeChosenItem(bool up)
    {
        if(up)
        {
            chosenItem--;
        }
        else
        {
            chosenItem++;
        }

        if (chosenItem < 0)
            chosenItem = GetInventorySize() - 1;
        if (chosenItem > GetInventorySize() - 1)
            chosenItem = 0;

    }
}
