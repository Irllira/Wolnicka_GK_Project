using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    private Item item;
   
    public static ItemInWorld CreateItem(Vector3 position, Item item)
    {
        Transform transform = Instantiate(item.GetObject(), position, Quaternion.identity);
        ItemInWorld iteminworld = transform.GetComponent<ItemInWorld>();

        iteminworld.SetItem(item);

        return iteminworld;
    }


    public void SetItem (Item item)
    {
        this.item = item;
   //     meshRenderer.
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
