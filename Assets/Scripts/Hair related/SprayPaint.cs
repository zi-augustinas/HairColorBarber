using System;
using PixelColourChanger;
using ScriptableObjectEvent;
using UnityEngine;

namespace HairBarber
{
    public class SprayPaint : MonoBehaviour
    {
        public Color col;
        [SerializeField]
        PaintSurface m_PaintSurface;

        [SerializeField]
        [Range(1f, 100f)]
        int size;
        [SerializeField]
        [Range(0f, 1f)]
        float hardness;

        [SerializeField]
        Transform m_SprayPoint;

        [SerializeField]
        Int_ScriptableObjectEvent m_SizeChangeEvent;

        bool m_Paint;
        int m_HairMask;
        double PI = 3.1415926535;
        ColourSprayLogic m_SprayLogic;

        // Start is called before the first frame update
        void Start()
        {
            m_SprayLogic = new ColourSprayLogic();
            m_HairMask = LayerMask.GetMask("Hair");
        }

        void OnEnable()
        {
            m_SizeChangeEvent.AddListener(UpdateSprayPaintSize);
        }

        void OnDisable()
        {
            m_SizeChangeEvent.RemoveListener(UpdateSprayPaintSize);
        }

        void UpdateSprayPaintSize(int eventValue)
        {
            size = eventValue;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_Paint)
                SprayThePaint();
        }

        public void Activate()
        {
            m_Paint = true;
        }

        public void Deactivating()
        {
            m_Paint = false;
        }

        void SprayThePaint()
        {
            RaycastHit hit;
            var ray = new Ray(m_SprayPoint.position, m_SprayPoint.forward);

            if (Physics.Raycast(ray, out hit, 0.25f, m_HairMask))
                if (hit.transform.gameObject != null)
                    m_SprayLogic.PixelColouring(hit.textureCoord, size, hardness, col, m_PaintSurface.texture2D);
        }
    }
}
