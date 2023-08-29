using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyComboBoxEdit {
    class ComboBoxHideItemsHelper : IDisposable {
        private ComboBoxEdit _comboBox;
        private List<int> _hiddenIndexes;
        public ComboBoxEdit Owner {
            get {
                return _comboBox;
            }
        }
        public List<int> HiddenIndexes {
            get {
                return _hiddenIndexes;
            }
        }
        private MeasureItemEventHandler _itemMeasure;

        public ComboBoxHideItemsHelper(ComboBoxEdit comboBox) {
            this._itemMeasure = null;
            this._hiddenIndexes = new List<int>();
            this._comboBox = comboBox;
            Init();
        }
        private void Init() {
            if (_comboBox != null) {
                if (_itemMeasure == null) {
                    _itemMeasure = new MeasureItemEventHandler(OnMeasureItem);
                    _comboBox.Properties.MeasureItem += _itemMeasure;
                }
            }
        }
        private void OnMeasureItem(object sender, MeasureItemEventArgs e) {
            if (_hiddenIndexes.Contains(e.Index)) {
                e.ItemHeight = 0;
                e.ItemWidth = 0;
            }
        }
        private void RefreshPopup() {
            ComboBoxPopupListBoxForm popupForm = _comboBox.GetPopupEditForm();
            if (popupForm != null) {
                popupForm.Parent = null;
                popupForm.Dispose();
            }
        }
        public int Add(int value) {
            int iResult = -1;
            if (_comboBox == null || _hiddenIndexes.Contains(value)) return iResult;
            try {
                RefreshPopup();
                _hiddenIndexes.Add(value);
                iResult = _hiddenIndexes.Count - 1;
            }
            catch {
            }
            return iResult;
        }
        public void AddRange(int[] indexes) {
            if (indexes == null) return;
            for (int i = 0; i < indexes.Length; i++)
                Add(indexes[i]);
        }
        public void Clear() {
            _hiddenIndexes.Clear();
            RefreshPopup();
        }
        public void Dispose() {
            if (_comboBox != null) {
                try {
                    _comboBox.Properties.MeasureItem -= _itemMeasure;
                    _comboBox = null;
                    _hiddenIndexes.Clear();
                    _hiddenIndexes = null;
                }
                catch {
                }
            }
        }
    }
}
