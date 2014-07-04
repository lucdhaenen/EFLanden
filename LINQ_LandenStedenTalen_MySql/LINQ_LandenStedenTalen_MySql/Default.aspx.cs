using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQ_LandenStedenTalen_MySql
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (var LSTEntities = new LandenStedenTalenEntities())
                    {
                        var LandenQuery = from land in LSTEntities.lst_landen
                                          orderby land.Naam
                                          select new { land.LandCode, land.Naam };
                        landenListBox.DataValueField = "LandCode";
                        landenListBox.DataTextField = "Naam";
                        landenListBox.DataSource = LandenQuery.ToList();
                        DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void landenListBox_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                using (var LSTEntities = new LandenStedenTalenEntities())
                {
                    string landCode;
                    if (landenListBox.SelectedValue != null)
                    {
                        landCode = landenListBox.SelectedValue;
                        var StedenQuery = from stad in LSTEntities.lst_steden
                                          where stad.LandCode == landCode
                                          orderby stad.Naam
                                          select stad.Naam;
                        stedenListBox.DataSource = StedenQuery.ToList();
                        stedenListBox.DataBind();

                        var TalenQuery = from t in LSTEntities.lst_talen
                                         from l in t.lst_Landen
                                         where l.LandCode == landCode
                                         select t.Naam;
                        talenListBox.DataSource = TalenQuery.ToList();
                        talenListBox.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ToevoegenButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var LSTEntities = new LandenStedenTalenEntities())
                {
                    if (landenListBox.SelectedIndex >= 0)
                    {
                        lst_Stad stad = new lst_Stad
                        {
                            Naam = stadTextBox.Text,
                            LandCode = landenListBox.SelectedValue
                        };
                        if (stadTextBox.Text != "")
                        {
                            LSTEntities.lst_steden.Add(stad);
                            LSTEntities.SaveChanges();
                            Response.Write("De entity is toegevoegd");
                            stadTextBox.Text = "";
                        }                        
                    }
                    else
                    {
                        Response.Write("Gelieve een land te selecteren");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}