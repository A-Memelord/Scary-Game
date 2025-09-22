using System.Collections;
using UnityEngine;

public class Vaulting : MonoBehaviour
{

    public LayerMask vaultLayer;
    private float playerHeight = 2f;
    private float playerRadius = 0.5f;
    public Bounds VaultBounds;

    void Update()
    {
        Vault();
    }

    private void Vault()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
                                // Position                              Size                 Vector2.zero                     Quaternion.identity  1               LayerMask                 out var secondHit
            if (Physics.BoxCast(transform.position + VaultBounds.center, VaultBounds.extents, Vector2.zero, out var secondHit, Quaternion.identity, Mathf.Infinity, vaultLayer))
            {
                print("vaultable in front");

                if (Physics.BoxCast((transform.position * playerRadius) + (Vector3.up * 0.6f * playerHeight), new Vector3(VaultBounds.size.x, VaultBounds.size.y, VaultBounds.size.z), Vector3.zero, Quaternion.identity, 1, vaultLayer))
                {
                    print("found place to land");
                    StartCoroutine(LerpVault(secondHit.point, 0.5f));
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + VaultBounds.center, VaultBounds.extents * 2);
        

    }

    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
