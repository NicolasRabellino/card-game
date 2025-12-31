using UnityEngine;

public class PlayCardSpot : MonoBehaviour
{
    public float spacing = 1.5f;

    private void OnTransformChildrenChanged()
    {
        OrganizeCards();
    }

    public void OrganizeCards()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;
        float startX = -((childCount - 1) * spacing) / 2f;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 targetPos = new Vector3(startX + (i * spacing), 0, 0);
            child.localPosition = targetPos;
        }
    }
}
