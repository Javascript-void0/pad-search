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
                .Replace("{Fire}",          icon(100))
                .Replace("{Water}",         icon(101))
                .Replace("{Wood}",          icon(102))
                .Replace("{Light}",         icon(103))
                .Replace("{Dark}",          icon(104))
                .Replace("{Heal}",          icon(105))
                .Replace("{Jammers}",       icon(106))
                .Replace("{Poison}",        icon(107))
                .Replace("{Bombs}",         icon(108))
                .Replace("{locks}",         icon(109))
                .Replace("{Nail}",          icon(110))
                .Replace("{Combo}",         icon(111))
                .Replace("{God}",           icon(112))
                .Replace("{Dragon}",        icon(113))
                .Replace("{Devil}",         icon(114))
                .Replace("{Machine}",       icon(115))
                .Replace("{Balanced}",      icon(116))
                .Replace("{Attacker}",      icon(117))
                .Replace("{Physical}",      icon(118))
                .Replace("{Healer}",        icon(119))

                .Replace("{Lethal Poison}",             icon(200))
                .Replace("{Enhance Material}",          icon(201))
                .Replace("{Enhanced Attack}",           icon(202))
                .Replace("{Enhanced Hp}",               icon(203))
                .Replace("{Enhanced Recovery}",         icon(204))
                .Replace("{Cross Attack}",              icon(205))
                .Replace("{Dragon Killer}",             icon(206))
                .Replace("{God Killer}",                icon(207))
                .Replace("{Devil Killer}",              icon(208))
                .Replace("{Balanced Killer}",           icon(209))
                .Replace("{Attacker Killer}",           icon(210))
                .Replace("{Physical Killer}",           icon(211))
                .Replace("{Healer Killer}",             icon(212))
                .Replace("{Enhanced Combos}",           icon(213))
                .Replace("{Skill Boost}",               icon(214))
                .Replace("{Skill Charge}",              icon(215))
                // .Replace("{Fire Surge}",                icon(216))
                // .Replace("{Water Surge}",               icon(217))
                // .Replace("{Wood Surge}",                icon(218))
                // .Replace("{Light Surge}",               icon(219))
                // .Replace("{Dark Surge}",                icon(220))
                // .Replace("{Heal Surge}",                icon(221))
                // .Replace("{Poison Surge}",              icon(222))
                .Replace("{Enhanced Surge}",            icon(223))
                // .Replace("{Attacker Enhanced}",         icon(224))
                .Replace("{Dungeon Bonus}",             icon(225))
                .Replace("{Recover Bind}",              icon(226))
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
    --size: 15;
    --orb-file: url('icon-orbs.png');
    --orb-size: 200% 1000%;
    --skills-file: url('icon-skills.png');
    --skills-size: 300% 4900%;
    --type-file: url('type.png');
    --type-size: 200% 1600%;
    --awoken-file: url('awoken.png');
    --awoken-size: 300% 14200%;
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
    background-repeat: none;
    aspect-ratio: 50 / 50;
    display: inline-block;
    color: transparent;
}

/* ================================= one word ================================= */
.icon[i=""100""] {                                        /* fire */
    background-position: 0% 0%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""101""] {                                        /* water */
    background-position: 0% 11.111111%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""102""] {                                        /* wood */
    background-position: 0% 22.222222%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""103""] {                                        /* light */
    background-position: 0% 33.333333%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""104""] {                                        /* dark */
    background-position: 0% 44.444444%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""105""] {                                        /* heal */
    background-position: 0% 55.555555%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""106""] {                                        /* jammers */
    background-position: 0% 66.666666%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""107""] {                                        /* poison */
    background-position: 0% 77.777777%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""108""] {                                        /* bombs */
    background-position: 0% 99.999999%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}

.icon[i=""109""] {                                        /* locks (11/48) */
    background-position: 100% 22.916666%;
    background-image: var(--skills-file);
    background-size: var(--skills-size);
}
.icon[i=""110""] {                                       /* nail (35/48) */
    background-position: 0% 72.916666%;
    background-image: var(--skills-file);
    background-size: var(--skills-size);
}
.icon[i=""111""] {                                       /* combo (44/48) */
    background-position: 0% 91.666666%;
    background-image: var(--skills-file);
    background-size: var(--skills-size);
}

.icon[i=""112""] {                                       /* god */
    background-position: 0% 33.333333%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""113""] {                                       /* dragon */
    background-position: 0% 26.666666%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""114""] {                                       /* devil */
    background-position: 0% 46.666666%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""115""] {                                       /* machine */
    background-position: 0% 53.333333%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""116""] {                                       /* balanced */
    background-position: 0% 6.666666%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""117""] {                                       /* attacker */
    background-position: 0% 40%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""118""] {                                       /* physical */
    background-position: 0% 13.333333%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""119""] {                                       /* healer */
    background-position: 0% 20%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}

/* ================================= two words ================================= */
.icon[i=""200""] {                                       /* lethal poison */
    background-position: 0% 88.888888%;
    background-image: var(--orb-file);
    background-size: var(--orb-size);
}
.icon[i=""201""] {                                        /* enhance material */
    background-position: 0% 93.333333%;
    background-image: var(--type-file);
    background-size: var(--type-size);
}
.icon[i=""202""] {                                        /* enhanced attack */
    background-position: 0% 1.418439%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""203""] {                                        /* enhanced hp */
    background-position: 0% 0.709219%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""204""] {                                        /* enhanced recovery */
    background-position: 0% 2.127659%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""205""] {                                        /* cross attack */
    background-position: 0% 55.319148%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""206""] {                                        /* dragon killer */
    background-position: 0% 21.985815%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""207""] {                                        /* god killer */
    background-position: 0% 22.695035%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""208""] {                                        /* devil killer */
    background-position: 0% 23.404255%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""209""] {                                        /* balanced killer */
    background-position: 0% 24.822695%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""210""] {                                        /* attacker killer */
    background-position: 0% 25.531914%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""211""] {                                        /* physical killer */
    background-position: 0% 26.241134%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""212""] {                                        /* healer killer */
    background-position: 0% 26.950354%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""213""] {                                        /* enhanced combos */
    background-position: 0% 30.496453%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""214""] {                                        /* skill boost */
    background-position: 0% 14.893617%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""215""] {                                        /* skill charge */
    background-position: 0% 36.170212%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""216""] {                                        /* fire surge */
    background-position: 0% 0%;
}
.icon[i=""217""] {                                        /* water surge */
    background-position: 0% 0%;
}
.icon[i=""218""] {                                        /* wood surge */
    background-position: 0% 0%;
}
.icon[i=""219""] {                                        /* light surge */
    background-position: 0% 0%;
}
.icon[i=""220""] {                                        /* dark surge */
    background-position: 0% 0%;
}
.icon[i=""221""] {                                        /* heal surge */
    background-position: 0% 0%;
}
.icon[i=""222""] {                                        /* poison surge */
    background-position: 0% 0%;
}
.icon[i=""223""] {                                        /* enhanced surge */
    background-position: 0% 68.75%;
    background-image: var(--skills-file);
    background-size: var(--skills-size);
}
.icon[i=""224""] {                                        /* attacker enhanced */
    background-position: 0% 0%;
}
.icon[i=""225""] {                                        /* dungeon bonus */
    background-position: 0% 45.390070%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}
.icon[i=""226""] {                                        /* recover bind */
    background-position: 0% 14.184397%;
    background-image: var(--awoken-file);
    background-size: var(--awoken-size);
}

/* ================================= three words ================================= */

/* ================================= more words ================================= */

";
    }
}

// ONE
// fire
// water
// wood
// light
// dark
// heal
// jammers
// poison
// bombs
// locks
// nail
// combo
// god
// dragon
// devil
// machine
// balanced
// attacker
// physical
// healer


// TWO
// lethal poison
// enhance material
// enhanced attack
// enhanced hp
// enhanced recovery
// cross attack
// dragon killer
// god killer
// devil killer
// balanced killer
// attacker killer
// physical killer
// healer killer
// enhanced combos
// skill boost
// skill charge
// fire surge
// water surge
// wood surge
// light surge
// dark surge
// heal surge
// poison surge
// enhanced surge
// attacker enhanced
// dungeon bonus
// recover bind


// THREE
// enhanced fire combo
// enhanced water combo
// enhanced wood combo
// enhanced light combo
// enhanced dark combo
// enhanced fire orbs+
// enhanced water orbs+
// enhanced wood orbs+
// enhanced light orbs+
// enhanced dark orbs+
// enhanced heal orbs+
// enhanced fire rows
// enhanced water rows
// enhanced wood rows
// enhanced light rows
// enhanced dark rows
// enhanced heal orbs
// super enhanced matching
// super enhanced combos
// damage void piercer
// add dragon type
// add devil type
// skill delay resistance
// part break bonus
// enhanced team hp
// extend move time+
// [L] increased attack
// [L] increased attack+
// [T] increased attack


// MORE
// fire & water attack
// water & wood attack
// wood & fire attack
// 50% or more HP Enhanced
// 50% or less HP Enhanced
