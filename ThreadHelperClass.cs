using System.Windows.Forms;

namespace _700100_ACW1
{
        public static class ThreadHelperClass
        {
            delegate void SetTextCallback(Form f, Control ctrl, string text);

            public static void SetText(Form form, Control ctrl, string text)
            {
                if (text == "" || text == null) return;
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text = text;
                }
            }

            public static void WriteText(Form form, Control ctrl, string text)
            {
                if (text == "" || text == null) return;
                if (ctrl.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    form.Invoke(d, new object[] { form, ctrl, text });
                }
                else
                {
                    ctrl.Text += text;
                }
            }
        }
    }