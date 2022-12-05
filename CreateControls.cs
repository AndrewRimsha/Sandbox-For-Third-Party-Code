using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _700100_ACW1
{
    class CreateControls
    {
        static public void createMessageBoxError(string messageLengthError, string captionLengthError)
        {
            MessageBox.Show(messageLengthError, captionLengthError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public RadioButton createRadioButton(string nameRadioButton, string textRadioButton)
        {
            RadioButton rb = new RadioButton();
            rb.Name = nameRadioButton;
            rb.Text = textRadioButton;
            rb.Dock = DockStyle.Fill;
            rb.FlatStyle = FlatStyle.Flat;
            return rb;
        }

        static public TableLayoutPanel createTableLayoutPanel(string nameTableLayoutPanel, int columnCount, int rowCount)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Name = nameTableLayoutPanel;
            tlp.Dock = DockStyle.Fill;
            //tlp.Margin = new Padding(0);
            tlp.ColumnCount = columnCount;
            tlp.RowCount = rowCount + 1;
            for (int i = 0; i < columnCount; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
            }
            for (int i = 0; i < rowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 23));
            }
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            return tlp;
        }

        static public TextBox createTextBox(string nameTextBox)
        {
            TextBox tb = new TextBox();
            tb.Name = nameTextBox;
            tb.Dock = DockStyle.Fill;
            tb.BorderStyle = BorderStyle.Fixed3D;
            return tb;
        }
    }
}
