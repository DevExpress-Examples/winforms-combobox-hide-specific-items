using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyComboBoxEdit {
    public partial class FormMain : Form {
        private ComboBoxHideItemsHelper _comboBoxHideItemsHelper;
        public FormMain() {
            InitializeComponent();
            this.indexesCheckedComboBox.EditValueChanged += indexesCheckedComboBox_EditValueChanged;
            this.indexesCheckedComboBox.Properties.EditValueType = DevExpress.XtraEditors.Repository.EditValueTypeCollection.List;
            this._comboBoxHideItemsHelper = new ComboBoxHideItemsHelper(comboBoxEdit1);
            PopulateIndexes();
        }
        void PopulateIndexes() {
            for (int i = 0; i < comboBoxEdit1.Properties.Items.Count; i++) {
                this.indexesCheckedComboBox.Properties.Items.Add(i, comboBoxEdit1.Properties.Items[i].ToString(), i < 2 ? CheckState.Checked : CheckState.Unchecked, true);
            }
        }
        private void indexesCheckedComboBox_EditValueChanged(object sender, EventArgs e) {
            _comboBoxHideItemsHelper.Clear();
            var checkedItems = indexesCheckedComboBox.Properties.GetCheckedItems() as List<object>;
            foreach (var item in checkedItems) {
                _comboBoxHideItemsHelper.Add((int)item);
            }
            return;
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            _comboBoxHideItemsHelper.Dispose();
            this.indexesCheckedComboBox.EditValueChanged -= indexesCheckedComboBox_EditValueChanged;
        }
    }
}