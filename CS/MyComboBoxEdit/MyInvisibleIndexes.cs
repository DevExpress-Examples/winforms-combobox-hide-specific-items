using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;



namespace MyComboBoxEdit
{
    class MyInvisibleIndexes
    {
        private ComboBoxEdit comboBox;
        private List<int> contentList;
        private CollectionChangeEventHandler itemsChange;
        private MeasureItemEventHandler itemMeasure;


        public int this[int index]
        {
            get
            {
                return contentList[index];
            }
            set
            {
                contentList[index] = value;
            }
        }



        public MyInvisibleIndexes(ComboBoxEdit comboBox)
        {
            itemsChange = null;
            itemMeasure = null;
            contentList = new List<int>();
            this.comboBox = comboBox;
            Init();
        }



        ~MyInvisibleIndexes()
        {
            if (comboBox != null)
            {
                try
                {
                    comboBox.Properties.MeasureItem -= itemMeasure;
                    comboBox.Properties.Items.CollectionChanged -= itemsChange;
                }
                catch
                {
                }
            }
        }



        private void Init()
        {
            if (comboBox != null)
            {
                if (itemsChange == null)
                {
                    itemsChange = new CollectionChangeEventHandler(OnItemsChanged);
                    comboBox.Properties.Items.CollectionChanged += itemsChange;
                }

                if (itemMeasure == null)
                {
                    itemMeasure = new MeasureItemEventHandler(OnMeasureItem);
                    comboBox.Properties.MeasureItem += itemMeasure;
                }
            }
        }



        private void OnItemsChanged(object sender, CollectionChangeEventArgs e)
        {
            ComboBoxEdit combo = sender as ComboBoxEdit;
            if (combo == null) return;

            int countItems = combo.Properties.Items.Count;
            if (countItems == 0)
            {
                contentList.Clear();
                return;
            }

            int ndx = 0;
            while (ndx < contentList.Count)
            {
                if (contentList[ndx] >= countItems)
                {
                    contentList.RemoveAt(ndx);
                    continue;
                }

                ndx++;
            }
        }



        private void OnMeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (contentList.Contains(e.Index))
            {
                e.ItemHeight = 0;
                e.ItemWidth = 0;
            }
        }



        private void ClearPopup()
        {
            Control control = (comboBox as DevExpress.Utils.Win.IPopupControl).PopupWindow;
            if (control != null)
            {
                control.Parent = null;
                control.Dispose();
            }
        }



        public int Add(int value)
        {
            int iResult = -1;
            if (comboBox == null || contentList.Contains(value)) return iResult;

            try
            {
                ClearPopup();
                contentList.Add(value);
                iResult = contentList.Count - 1;
            }
            catch
            {
            }

            return iResult;
        }



        public void AddRange(int[] indexes)
        {
            if (indexes == null) return;

            for (int i = 0; i < indexes.Length; i++) Add(indexes[i]);
        }



        public void Clear()
        {
            contentList.Clear();
        }



        public bool Contains(int value)
        {
            return contentList.Contains(value);
        }



        public int IndexOf(int value)
        {
            return contentList.IndexOf(value);
        }



        public int Count
        {
            get
            {
                return contentList.Count;
            }
        }



        public void Remove(int value)
        {
            contentList.Remove(value);
        }
    }
}
