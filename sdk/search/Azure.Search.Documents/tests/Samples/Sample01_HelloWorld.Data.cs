// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class HelloWorld
    {
        // Rather than store these in a file and fix EOL to be \n in the root .gitattributes (making this less portable)
        // define a string literal with \n for new lines to be used in the sample to normalize line endings across test platforms.
        private static readonly string CountriesSolrSynonymMap =
            "Afghanistan,AF,AFG\n" +
            "Åland Islands,AX,ALA\n" +
            "Albania,AL,ALB\n" +
            "Algeria,DZ,DZA\n" +
            "American Samoa,AS,ASM\n" +
            "Andorra,AD,AND\n" +
            "Angola,AO,AGO\n" +
            "Anguilla,AI,AIA\n" +
            "Antarctica,AQ,ATA\n" +
            "Antigua and Barbuda,AG,ATG\n" +
            "Argentina,AR,ARG\n" +
            "Armenia,AM,ARM\n" +
            "Aruba,AW,ABW\n" +
            "Australia,AU,AUS\n" +
            "Austria,AT,AUT\n" +
            "Azerbaijan,AZ,AZE\n" +
            "Bahamas,BS,BHS\n" +
            "Bahrain,BH,BHR\n" +
            "Bangladesh,BD,BGD\n" +
            "Barbados,BB,BRB\n" +
            "Belarus,BY,BLR\n" +
            "Belgium,BE,BEL\n" +
            "Belize,BZ,BLZ\n" +
            "Benin,BJ,BEN\n" +
            "Bermuda,BM,BMU\n" +
            "Bhutan,BT,BTN\n" +
            "Bolivia,Plurinational State of Bolivia,BO,BOL\n" +
            "Bonaire,Sint Eustatius and Saba,BQ,BES\n" +
            "Bosnia and Herzegovina,BA,BIH\n" +
            "Botswana,BW,BWA\n" +
            "Bouvet Island,BV,BVT\n" +
            "Brazil,BR,BRA\n" +
            "British Indian Ocean Territory,IO,IOT\n" +
            "Brunei Darussalam,BN,BRN\n" +
            "Bulgaria,BG,BGR\n" +
            "Burkina Faso,BF,BFA\n" +
            "Burundi,BI,BDI\n" +
            "Cabo Verde,CV,CPV\n" +
            "Cambodia,KH,KHM\n" +
            "Cameroon,CM,CMR\n" +
            "Canada,CA,CAN\n" +
            "Cayman Islands,KY,CYM\n" +
            "Central African Republic,CF,CAF\n" +
            "Chad,TD,TCD\n" +
            "Chile,CL,CHL\n" +
            "China,CN,CHN\n" +
            "Christmas Island,CX,CXR\n" +
            "Cocos (Keeling) Islands,CC,CCK\n" +
            "Colombia,CO,COL\n" +
            "Comoros,KM,COM\n" +
            "Congo,CG,COG\n" +
            "Democratic Republic of the Congo,CD,COD\n" +
            "Cook Islands,CK,COK\n" +
            "Costa Rica,CR,CRI\n" +
            "Côte d'Ivoire,CI,CIV\n" +
            "Croatia,HR,HRV\n" +
            "Cuba,CU,CUB\n" +
            "Curaçao,CW,CUW\n" +
            "Cyprus,CY,CYP\n" +
            "Czechia,CZ,CZE\n" +
            "Denmark,DK,DNK\n" +
            "Djibouti,DJ,DJI\n" +
            "Dominica,DM,DMA\n" +
            "Dominican Republic,DO,DOM\n" +
            "Ecuador,EC,ECU\n" +
            "Egypt,EG,EGY\n" +
            "El Salvador,SV,SLV\n" +
            "Equatorial Guinea,GQ,GNQ\n" +
            "Eritrea,ER,ERI\n" +
            "Estonia,EE,EST\n" +
            "Eswatini,SZ,SWZ\n" +
            "Ethiopia,ET,ETH\n" +
            "Falkland Islands (Malvinas),FK,FLK\n" +
            "Faroe Islands,FO,FRO\n" +
            "Fiji,FJ,FJI\n" +
            "Finland,FI,FIN\n" +
            "France,FR,FRA\n" +
            "French Guiana,GF,GUF\n" +
            "French Polynesia,PF,PYF\n" +
            "French Southern Territories,TF,ATF\n" +
            "Gabon,GA,GAB\n" +
            "Gambia,GM,GMB\n" +
            "Georgia,GE,GEO\n" +
            "Germany,DE,DEU\n" +
            "Ghana,GH,GHA\n" +
            "Gibraltar,GI,GIB\n" +
            "Greece,GR,GRC\n" +
            "Greenland,GL,GRL\n" +
            "Grenada,GD,GRD\n" +
            "Guadeloupe,GP,GLP\n" +
            "Guam,GU,GUM\n" +
            "Guatemala,GT,GTM\n" +
            "Guernsey,GG,GGY\n" +
            "Guinea,GN,GIN\n" +
            "Guinea-Bissau,GW,GNB\n" +
            "Guyana,GY,GUY\n" +
            "Haiti,HT,HTI\n" +
            "Heard Island and McDonald Islands,HM,HMD\n" +
            "Holy See,VA,VAT\n" +
            "Honduras,HN,HND\n" +
            "Hong Kong,HK,HKG\n" +
            "Hungary,HU,HUN\n" +
            "Iceland,IS,ISL\n" +
            "India,IN,IND\n" +
            "Indonesia,ID,IDN\n" +
            "Iran,Islamic Republic of Iran,IR,IRN\n" +
            "Iraq,IQ,IRQ\n" +
            "Ireland,IE,IRL\n" +
            "Isle of Man,IM,IMN\n" +
            "Israel,IL,ISR\n" +
            "Italy,IT,ITA\n" +
            "Jamaica,JM,JAM\n" +
            "Japan,JP,JPN\n" +
            "Jersey,JE,JEY\n" +
            "Jordan,JO,JOR\n" +
            "Kazakhstan,KZ,KAZ\n" +
            "Kenya,KE,KEN\n" +
            "Kiribati,KI,KIR\n" +
            "Democratic People's Republic of Korea,KP,PRK\n" +
            "Korea,Republic of Korea,KR,KOR\n" +
            "Kuwait,KW,KWT\n" +
            "Kyrgyzstan,KG,KGZ\n" +
            "Lao People's Democratic Republic,LA,LAO\n" +
            "Latvia,LV,LVA\n" +
            "Lebanon,LB,LBN\n" +
            "Lesotho,LS,LSO\n" +
            "Liberia,LR,LBR\n" +
            "Libya,LY,LBY\n" +
            "Liechtenstein,LI,LIE\n" +
            "Lithuania,LT,LTU\n" +
            "Luxembourg,LU,LUX\n" +
            "Macao,MO,MAC\n" +
            "Madagascar,MG,MDG\n" +
            "Malawi,MW,MWI\n" +
            "Malaysia,MY,MYS\n" +
            "Maldives,MV,MDV\n" +
            "Mali,ML,MLI\n" +
            "Malta,MT,MLT\n" +
            "Marshall Islands,MH,MHL\n" +
            "Martinique,MQ,MTQ\n" +
            "Mauritania,MR,MRT\n" +
            "Mauritius,MU,MUS\n" +
            "Mayotte,YT,MYT\n" +
            "Mexico,MX,MEX\n" +
            "Micronesia,Federated States of Micronesia,FM,FSM\n" +
            "Moldova,Republic of Moldova,MD,MDA\n" +
            "Monaco,MC,MCO\n" +
            "Mongolia,MN,MNG\n" +
            "Montenegro,ME,MNE\n" +
            "Montserrat,MS,MSR\n" +
            "Morocco,MA,MAR\n" +
            "Mozambique,MZ,MOZ\n" +
            "Myanmar,MM,MMR\n" +
            "Namibia,NA,NAM\n" +
            "Nauru,NR,NRU\n" +
            "Nepal,NP,NPL\n" +
            "Netherlands,NL,NLD\n" +
            "New Caledonia,NC,NCL\n" +
            "New Zealand,NZ,NZL\n" +
            "Nicaragua,NI,NIC\n" +
            "Niger,NE,NER\n" +
            "Nigeria,NG,NGA\n" +
            "Niue,NU,NIU\n" +
            "Norfolk Island,NF,NFK\n" +
            "North Macedonia,MK,MKD\n" +
            "Northern Mariana Islands,MP,MNP\n" +
            "Norway,NO,NOR\n" +
            "Oman,OM,OMN\n" +
            "Pakistan,PK,PAK\n" +
            "Palau,PW,PLW\n" +
            "Palestine,State of Palestine,PS,PSE\n" +
            "Panama,PA,PAN\n" +
            "Papua New Guinea,PG,PNG\n" +
            "Paraguay,PY,PRY\n" +
            "Peru,PE,PER\n" +
            "Philippines,PH,PHL\n" +
            "Pitcairn,PN,PCN\n" +
            "Poland,PL,POL\n" +
            "Portugal,PT,PRT\n" +
            "Puerto Rico,PR,PRI\n" +
            "Qatar,QA,QAT\n" +
            "Réunion,RE,REU\n" +
            "Romania,RO,ROU\n" +
            "Russia,Russian Federation,RU,RUS\n" +
            "Rwanda,RW,RWA\n" +
            "Saint Barthélemy,BL,BLM\n" +
            "Saint Helena,Ascension and Tristan da Cunha,SH,SHN\n" +
            "Saint Kitts and Nevis,KN,KNA\n" +
            "Saint Lucia,LC,LCA\n" +
            "Saint Martin (French part),MF,MAF\n" +
            "Saint Pierre and Miquelon,PM,SPM\n" +
            "Saint Vincent and the Grenadines,VC,VCT\n" +
            "Samoa,WS,WSM\n" +
            "San Marino,SM,SMR\n" +
            "Sao Tome and Principe,ST,STP\n" +
            "Saudi Arabia,SA,SAU\n" +
            "Senegal,SN,SEN\n" +
            "Serbia,RS,SRB\n" +
            "Seychelles,SC,SYC\n" +
            "Sierra Leone,SL,SLE\n" +
            "Singapore,SG,SGP\n" +
            "Sint Maarten (Dutch part),SX,SXM\n" +
            "Slovakia,SK,SVK\n" +
            "Slovenia,SI,SVN\n" +
            "Solomon Islands,SB,SLB\n" +
            "Somalia,SO,SOM\n" +
            "South Africa,ZA,ZAF\n" +
            "South Georgia and the South Sandwich Islands,GS,SGS\n" +
            "South Sudan,SS,SSD\n" +
            "Spain,ES,ESP\n" +
            "Sri Lanka,LK,LKA\n" +
            "Sudan,SD,SDN\n" +
            "Suriname,SR,SUR\n" +
            "Svalbard and Jan Mayen,SJ,SJM\n" +
            "Sweden,SE,SWE\n" +
            "Switzerland,CH,CHE\n" +
            "Syrian Arab Republic,SY,SYR\n" +
            "Taiwan,Province of China,TW,TWN\n" +
            "Tajikistan,TJ,TJK\n" +
            "Tanzania,United Republic of Tanzania,TZ,TZA\n" +
            "Thailand,TH,THA\n" +
            "Timor-Leste,TL,TLS\n" +
            "Togo,TG,TGO\n" +
            "Tokelau,TK,TKL\n" +
            "Tonga,TO,TON\n" +
            "Trinidad and Tobago,TT,TTO\n" +
            "Tunisia,TN,TUN\n" +
            "Turkey,TR,TUR\n" +
            "Turkmenistan,TM,TKM\n" +
            "Turks and Caicos Islands,TC,TCA\n" +
            "Tuvalu,TV,TUV\n" +
            "Uganda,UG,UGA\n" +
            "Ukraine,UA,UKR\n" +
            "United Arab Emirates,AE,ARE\n" +
            "United Kingdom of Great Britain and Northern Ireland,GB,GBR\n" +
            "United States of America,US,USA\n" +
            "United States Minor Outlying Islands,UM,UMI\n" +
            "Uruguay,UY,URY\n" +
            "Uzbekistan,UZ,UZB\n" +
            "Vanuatu,VU,VUT\n" +
            "Venezuela (Bolivarian Republic of),VE,VEN\n" +
            "Viet Nam,VN,VNM\n" +
            "Virgin Islands (British),VG,VGB\n" +
            "Virgin Islands (U.S.),VI,VIR\n" +
            "Wallis and Futuna,WF,WLF\n" +
            "Western Sahara,EH,ESH\n" +
            "Yemen,YE,YEM\n" +
            "Zambia,ZM,ZMB\n" +
            "Zimbabwe,ZW,ZWE\n";
    }
}
