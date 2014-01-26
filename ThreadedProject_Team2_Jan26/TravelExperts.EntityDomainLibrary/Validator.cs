/*This Validator class was created by Andrew Goguen on Jan. 15, 2014, Yu Wen also added 2 methods on Jan 20.
 * for the Travel Experts Threaded Project
 * It validates the Controls and The Input from the User
 * It is a static class with multiple boolean methods for validating
 * text fields, integer fields, etc.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //add a forms reference So we can access the Control class
using System.Text.RegularExpressions;       //So we can use a regular expression

namespace TravelExperts.EntityDomainLibrary
{
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// A Method to make sure a given control is not empty
        /// </summary>
        /// <param name="control">Control</param>
        /// <returns>bool</returns>
        public static bool IsPresent(Control control)  
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.SelectAll();
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", Title);
                    comboBox.SelectAll();
                    comboBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.Label")
            {
                Label label = (Label)control;
                if (label.Text == "")
                {
                    label.Select();
                    label.Focus();
                    return false;

                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
            {
                DateTimePicker dtp = (DateTimePicker)control;
                if (control.Text == "")
                {
                    MessageBox.Show(dtp.Tag + " is required field, please choose a date", "Choose a date");
                    dtp.Focus();
                    return false;
                }
               
            }
            return true;
        }

        /// <summary>
        /// checks the textbox for a numeric value
        /// </summary>
        /// <param name="textbox">textbox</param>
        /// <returns>Boolean</returns>
        public static bool IsNumeric(TextBox textbox)
        {
            //try { int.Parse(textbox.Text); return true; }
            //catch { }
            try { long.Parse(textbox.Text); return true; }
            catch { }
            try { ulong.Parse(textbox.Text); return true; }
            catch { }
            try { float.Parse(textbox.Text); return true; }
            catch { }
            try { double.Parse(textbox.Text); return true; }
            catch { }
            try { decimal.Parse(textbox.Text); return true; }
            catch { }
            return false;
        }

        /// <summary>
        /// check each character to make sure it is Alphabetical returning true if it passes
        /// </summary>
        /// <param name="textbox"></param>
        /// <returns></returns>
        public static bool IsAlphabetical(TextBox textbox)
        {
            string pattern = @"^[a-zA-Z\s-]{1,50}";     //changed this method to use a regular expression
            Regex reg = new Regex(pattern);             //I think it's a bit cleaner code and now will accept hyphens
            return reg.IsMatch(textbox.Text);

        }

        /// <summary>
        /// A method to format a name passed in 
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>the String</returns>
        public static string FormatedName(string name)
        {
            //declare the variables that we use locally
            string formattedName = "";
            string[] names;
            char[] letters;

            name = name.Trim();
            names = name.Split();

            foreach (string n in names)
            {
                if (n == "") //this handles the multiple spaces between names
                {
                    continue;
                }
                else
                {
                    letters = n.ToCharArray();                                  //once validation has passed break into array of Chars
                    formattedName += letters[0].ToString().ToUpper();       //Capitalize the first letter

                    for (int i = 1; 0 < letters.Length; i++)
                    {
                        formattedName += letters[i].ToString().ToLower();   //make sure all other letters 
                    }                                                               //are lowercase and add them to the name
                    formattedName += " ";                                   //Add a space between names
                }
            }                
            return formattedName.TrimEnd();
        }


        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min.ToString()
                    + " and " + max.ToString() + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //validate the package start date and end date
        public static bool AppropriateDate(DateTime date1, DateTime date2)
        {
            bool bDate = true; 

            if (date2 < date1)
            {
                bDate = false;
                MessageBox.Show("The end date is earlier than the start date, please re-enter the dates", "Wrong Date");
            }           

            return bDate;
        }

        //validate the commission for package
        public static bool CheckCommission(double price, double commission)
        {
            bool bComm;

            if (commission < 0)
            {
                bComm = false;
                MessageBox.Show("Commission only can be positive amount", "Wrong input");
            }
            else
            {
                if (commission >= price)
                {
                    bComm = false;
                    MessageBox.Show("Commission can not be greater than base price of package", "Wrong input");
                }
                else
                    bComm = true;
            }
            return bComm;
        }

    }
}
