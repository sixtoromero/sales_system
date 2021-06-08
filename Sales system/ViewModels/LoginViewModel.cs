using Connection;
using Sales_system.Library;
using Sales_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sales_system.ViewModels
{
    public class LoginViewModel: UserModel
    {
        private ICommand _command;
        private TextBox _textBoxEmail;
        private PasswordBox _textBoxPass;
        private String date = DateTime.Now.ToString("dd/MMM/yyyy");
        private Frame rootFrame = Window.Current.Content as Frame;
        private SQLiteConnections _sqlite;

        //private ConectionAPI _conn;
        private Connections _conn;

        public LoginViewModel(object[] campos)
        {
            _textBoxEmail = (TextBox) campos[0];
            _textBoxPass = (PasswordBox) campos[1];
            _conn = new Connections();
            //_conn = new ConectionAPI("http://localhost:13860/api/TUsers/");
            _sqlite = new SQLiteConnections();

        }

        public ICommand IniciarComando
        {
            get
            {
                return _command ?? (_command = new CommandHandler(async () =>
                {
                    await iniciarAsync();
                }));
            }
        }

        private async Task iniciarAsync()
        {
            if (Email == null || Email.Equals(""))
            {
                EmailMessage = "Ingrese el email";
                _textBoxEmail.Focus(FocusState.Programmatic);
            }
            else
            {
                if (TextBoxEvent.IsValidEmail(Email))
                {
                    if (Password == null || Password.Equals(""))
                    {
                        PasswordMessage = "Ingrese el password";
                        _textBoxPass.Focus(FocusState.Programmatic);
                    } 
                    else
                    {
                        if (Password.Length >= 5)
                        {
                            try
                            {
                                var user = _conn.TUsers.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList();
                                //var user = _conn.GetTUserLogin(Email, Password).Result;
                                if (user != null)
                                {
                                    //user.Date = DateTime.Now.ToString("dd/MMM/yyyy");
                                    //_sqlite.Connection.Insert(user);
                                    //rootFrame.Navigate(typeof(MainPage));

                                    var dataUser = user.ElementAt(0);
                                    dataUser.Date = DateTime.Now.ToString("dd/MMM/yyy");
                                    _sqlite.Connection.Insert(dataUser);
                                    rootFrame.Navigate(typeof(MainPage));
                                }
                                else
                                {
                                    Message = "Contraseña o Email incorrectos";
                                }
                            }
                            catch (Exception ex)
                            {
                                Message = ex.Message;                                
                            }                            
                        }
                        else
                        {
                            PasswordMessage = "Ingrese más de 4 dígitos en la contraseña";
                            _textBoxPass.Focus(FocusState.Programmatic);
                        }
                    }
                }
                else
                {
                    EmailMessage = "El email no es válido";
                    _textBoxEmail.Focus(FocusState.Programmatic);
                }
            }
        }
    }
}
