using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.GeneratedCode;
using PokemonGo.RocketAPI.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace PokemonsStatusWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        static Client _client;
        static Settings _clientSettings = new Settings();
        static Inventory _inventory;
        static DataTable t;

        static GoogleLogin.DeviceCodeModel deviceCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                t = new DataTable();
                t.Columns.Add("Pokemon", typeof(string));
                t.Columns.Add("CreationTime", typeof(DateTime));
                t.Columns.Add("LV", typeof(double));
                t.Columns.Add("CP", typeof(int));
                t.Columns.Add("MaxCP", typeof(int));
                t.Columns.Add("ATK", typeof(int));
                t.Columns.Add("DEF", typeof(int));
                t.Columns.Add("STA", typeof(int));
                t.Columns.Add("CPPerfection", typeof(double));
                t.Columns.Add("IVPerfection", typeof(double));
            }
            
            ASPxGridView1.DataSource = t;
            ASPxGridView1.DataBind();
        }

        private async Task ViewPokemons()
        {
            t.Clear();
            var Pokemons = await _inventory.GetPokemons();
            foreach (var Pokemon in Pokemons)
            {
                DataRow newrow = t.NewRow();
                newrow["Pokemon"] = Pokemon.PokemonId.ToString();
                DateTime time = DateTime.MinValue;
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
                newrow["CreationTime"] = startTime.AddMilliseconds(Pokemon.CreationTimeMs);
                newrow["LV"] = PokemonInfo.GetLevel(Pokemon);
                newrow["CP"] = Pokemon.Cp;
                newrow["MaxCP"] = PokemonInfo.CalculateMaxCP(Pokemon);
                newrow["ATK"] = Pokemon.IndividualAttack;
                newrow["DEF"] = Pokemon.IndividualDefense;
                newrow["STA"] = Pokemon.IndividualStamina;
                newrow["CPPerfection"] = Math.Round(PokemonInfo.CalculatePokemonPerfection(Pokemon), 2);
                newrow["IVPerfection"] = Math.Round(PokemonInfo.CalculatePokemonPerfection2(Pokemon), 2);
                t.Rows.Add(newrow);
            }
            ASPxGridView1.DataSource = t.AsDataView();
            ASPxGridView1.DataBind();
        }

        protected void PtcSubmit_Click(object sender, EventArgs e)
        {
            Ptc();

        }
        public static void GoogleSettings(double lat, double lng)
        {
            _clientSettings.AuthType = AuthType.Google;
            _clientSettings.DefaultLatitude = lat;
            _clientSettings.DefaultLongitude = lng;
        }
        public static void PtcSettings(string user, string pass, double lat, double lng)
        {
            _clientSettings.AuthType = AuthType.Ptc;
            _clientSettings.PtcUsername = user;
            _clientSettings.PtcPassword = pass;
            _clientSettings.DefaultLatitude = lat;
            _clientSettings.DefaultLongitude = lng;
        }
        async void Ptc()
        {
            lab.Text = "";
            Captcha.Text = "";
            PtcSettings(UserName.Text, Password.Text, 37.808586, -122.409836);
            try
            {
                    _client = new Client(_clientSettings);
                    await _client.DoPtcLogin(_clientSettings.PtcUsername, _clientSettings.PtcPassword);
                    await _client.SetServer();
                    _inventory = new Inventory(_client);
            }
            catch(Exception ex)
            {
                lab.Text = ex.Message;
                return;
            }

            try
            {
                await ViewPokemons();
            }
            catch (Exception ex)
            {
                lab.Text = ex.Message;
            }
        }


        async void GetCaptcha()
        {
            try
            {
                deviceCode = await GoogleLogin.GetDeviceCode();
                Captcha.Text = "请在www.google.com/device 中输入 " + deviceCode.user_code+" ！";
            }
            catch
            {
                lab.Text = "获得Google User_Code失败";
            }
        }

        private async void Google()
        {
            lab.Text = "";
            Captcha.Text = "";
            GoogleSettings(37.808586, -122.409836);
            try
            {
                _client = new Client(_clientSettings);
                await _client.DoGoogleLogin(deviceCode);
                await _client.SetServer();
            }
            catch
            {
                lab.Text = "GoogleLogin 失败";
            }
            try
            {
                _inventory = new Inventory(_client);
                await ViewPokemons();
            }
            catch
            {
                lab.Text = "获得PM信息失败";
            }
            
        }

        protected void GoogleSubmit_Click(object sender, EventArgs e)
        {
            Google();
        }

        protected void GetGoogleCaptcha_Click(object sender, EventArgs e)
        {
            GetCaptcha();
            
        }

        protected void ExportView_Click(object sender, EventArgs e)
        {
            Exporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.DataAware });
        }
    }
}
