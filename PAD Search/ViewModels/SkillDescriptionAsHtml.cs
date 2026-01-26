using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PAD_Search.ViewModels
{
    public class SkillDescriptionAsHtml
    {
        private static string icon(int id)
        {
            return @"</span><span class=""icon"" i=""" + id + @""">.</span><span>";
        }
        public static HtmlWebViewSource ToHtml(string skillDescription)
        {
            var replaced = "<span>" + skillDescription
                .Replace("\n", "<br>")
                .Replace("{Fire}", icon(0))
                .Replace("{Water}", icon(1))
                .Replace("{Wood}", icon(2))
                .Replace("{Light}", icon(3))
                .Replace("{Dark}", icon(4))
                .Replace("{Heal}", icon(5))
                .Replace("{Jammers}", icon(6))
                .Replace("{Poison}", icon(7))
                .Replace("{Lethal Poison}", icon(8))
                .Replace("{Bombs}", icon(9))
                .Replace("{locks}", icon(10))
                + "</span>";
            var html = @"
                <html>
                    <body>
                        <style>" + style + @"</style>" + 
                        replaced + @"
                    </body>
                </html>";
            var source = new HtmlWebViewSource();
            source.BaseUrl = "file:///android_asset/";
            source.Html = html;
            return source;
        }





        private const string style = @"
:root {
    --size: 15
}
body {
    background-color: #1d1d1d;
    color: #bbbbbb;
    padding: 0;
    margin: 0;
}
span {
    font-size: var(--size);
}
.icon {
    width: var(--size);
    height: var(--size);
    background-image: url('icon-orbs.png');
    background-size: 200% 1000%;
    background-repeat: none;
    aspect-ratio: 50 / 50;
    display: inline-block;
    color: transparent;
}
.icon[i=""0""] { background-position: 0% 0%; }         /* fire */
.icon[i=""1""] { background-position: 0% 11.111111%; } /* water */
.icon[i=""2""] { background-position: 0% 22.222222%; } /* wood */
.icon[i=""3""] { background-position: 0% 33.333333%; } /* light */
.icon[i=""4""] { background-position: 0% 44.444444%; } /* dark */
.icon[i=""5""] { background-position: 0% 55.555555%; } /* heal */
.icon[i=""6""] { background-position: 0% 66.666666%; } /* jammers */
.icon[i=""7""] { background-position: 0% 77.777777%; } /* poison */
.icon[i=""8""] { background-position: 0% 88.888888%; } /* lethal poison */
.icon[i=""9""] { background-position: 0% 99.999999%; } /* bombs */

.icon[i=""10""] {                                      /* locks */
    background-image: url('icon-skills.png');
    background-position: 100% 22.916666%;
    background-size: 300% 4900%;
}
.icon[i=""11""] {                                      /* nail */
    background-image: url('icon-skills.png');
    background-position: 100% 71.340425%;
    background-size: 300% 4900%;
}
.icon[i=""12""] {                                      /* combo */
    background-image: url('icon-skills.png');
    background-position: 100% 91.489361%;
    background-size: 300% 4900%;
}
";
    }
}

//enhanced fire combo
//enhanced water combo
//enhanced wood combo
//enhanced light combo
//enhanced dark combo
//enhanced fire rows
//enhanced water rows
//enhanced wood rows
//enhanced light rows
//enhanced dark rows
//enhanced heal orbs
//super enhanced matching
//super enhanced combo
//damage void piercer

//attacker enhanced
//{50% or more HP Enhanced}
//{50% or less HP Enhanced}

///* surge */
//fire surge
//water surge
//wood surge
//light surge
//dark surge
//heal surge
//poison surge
//enhanced surge

///* types */
//god
//dragon
//devil
//machine
//balanced
//attacker
//physical
//healder
//evoMaterial
//awakenMaterial
//enhance material
//redeemableMaterial

//ls
//enhanced attack
//enhanced hp
//enhanced recovery
//cross attack
//dragon killer
//god killer
//devil killer
//balanced killer
//attacker killer
//physical killer
//healer killer
//enhanced combos
//skill boost
//skill charge
