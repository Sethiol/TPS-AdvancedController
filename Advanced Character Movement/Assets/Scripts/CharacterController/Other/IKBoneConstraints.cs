using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKBoneConstraints : MonoBehaviour
{
    [System.Serializable]
    public class BoneClamp
    { //Class for bones with min and max XYZ rotation values
        public Transform bone;
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        public float minZ;
        public float maxZ;
    }

    public BoneClamp[] boneClamps;
    private Vector3 newV3 = new Vector3(0f, 0f, 0f);
    // Update is called once per frame
    void Update()
    {
        foreach (BoneClamp clamp in boneClamps)
        {
            clamp.minX = Mathf.Clamp(clamp.minX, -360, 360);
            clamp.minY = Mathf.Clamp(clamp.minY, -360, 360);
            clamp.minZ = Mathf.Clamp(clamp.minZ, -360, 360);
            clamp.maxX = Mathf.Clamp(clamp.maxX, -360, 360);
            clamp.maxY = Mathf.Clamp(clamp.maxY, -360, 360);
            clamp.maxZ = Mathf.Clamp(clamp.maxZ, -360, 360);
        }
    }

    // We use LateUpdate to grab the rotation from the Transform after all Updates from
    // other scripts have occured
    void LateUpdate()
    {
        foreach (BoneClamp clamp in boneClamps)
        {
            float rotationX = clamp.bone.localEulerAngles.x;
            float rotationY = clamp.bone.localEulerAngles.y;
            float rotationZ = clamp.bone.localEulerAngles.z;

            rotationX = Mathf.Clamp(rotationX, clamp.minX, clamp.maxX);
            rotationY = Mathf.Clamp(rotationY, clamp.minY, clamp.maxY);
            rotationZ = Mathf.Clamp(rotationZ, clamp.minZ, clamp.maxZ);

            newV3.x = rotationX;
            newV3.y = rotationY;
            newV3.z = rotationZ;

            clamp.bone.localEulerAngles = newV3;
        }
    }
}
