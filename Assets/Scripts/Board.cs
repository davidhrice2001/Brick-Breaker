using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] int columns;
    [SerializeField] int rows;
    [SerializeField] Vector2 blockSize;
    int blocksRemaining;
    public UnityEvent boardClearedEvent;

    void Start()
    {
        for (int row = 0; row < rows; ++row)
        {
            for (int column = 0; column < columns; ++column)
            {
                var BlockInstance = Instantiate(blockPrefab);
                var Block = BlockInstance.GetComponent<Block>();
                Block.health = row;
                Block.destroyedEvent.AddListener(BlockDestroyed);

                BlockInstance.transform.SetParent(transform);
                BlockInstance.transform.localPosition = new Vector3(column * blockSize.x, row * blockSize.y, 0);
            }
        }
        blocksRemaining = rows * columns;
    }

    void BlockDestroyed()
    {
        blocksRemaining--;
        if (blocksRemaining == 0)
        {
            boardClearedEvent.Invoke();
        }
    }
}
