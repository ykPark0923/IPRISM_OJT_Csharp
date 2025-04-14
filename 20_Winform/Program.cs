using System;


namespace Winform_20
{

    class MyForm : System.Windows.Forms.Form
    {

    }
    class MAinApp
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            form.Click += new EventHandler(
                (sender, eventArgs) =>
                {
                    Application.Exit();
                });

            Application.Run(form);
        }
    }
}

