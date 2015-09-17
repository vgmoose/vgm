// Created by iWeb 3.0.2 local-build-20110227

function writeMovie1()
{detectBrowser();if(windowsInternetExplorer)
{document.write('<object id="id3" classid="clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B" codebase="http://www.apple.com/qtactivex/qtplugin.cab" width="552" height="361" style="height: 361px; left: 74px; position: absolute; top: 1619px; width: 552px; z-index: 1; "><param name="src" value="../../../../Media/TutorialText.mov" /><param name="controller" value="true" /><param name="autoplay" value="false" /><param name="scale" value="tofit" /><param name="volume" value="100" /><param name="loop" value="false" /></object>');}
else if(isiPhone)
{document.write('<object id="id3" type="video/quicktime" width="552" height="361" style="height: 361px; left: 74px; position: absolute; top: 1619px; width: 552px; z-index: 1; "><param name="src" value="11_Custom_Text_Tutorial_files/TutorialText.jpg"/><param name="target" value="myself"/><param name="href" value="../../../../../Media/TutorialText.mov"/><param name="controller" value="true"/><param name="scale" value="tofit"/></object>');}
else
{document.write('<object id="id3" type="video/quicktime" width="552" height="361" data="../../../../Media/TutorialText.mov" style="height: 361px; left: 74px; position: absolute; top: 1619px; width: 552px; z-index: 1; "><param name="src" value="../../../../Media/TutorialText.mov"/><param name="controller" value="true"/><param name="autoplay" value="false"/><param name="scale" value="tofit"/><param name="volume" value="100"/><param name="loop" value="false"/></object>');}}
setTransparentGifURL('../../../../Media/transparent.gif');function applyEffects()
{var registry=IWCreateEffectRegistry();registry.registerEffects({shadow_0:new IWShadow({blurRadius:4,offset:new IWPoint(1.4142,1.4142),color:'#000000',opacity:0.500000}),shadow_1:new IWShadow({blurRadius:4,offset:new IWPoint(1.4142,1.4142),color:'#000000',opacity:0.500000}),shadow_2:new IWShadow({blurRadius:4,offset:new IWPoint(1.4142,1.4142),color:'#000000',opacity:0.500000})});registry.applyEffects();}
function hostedOnDM()
{return false;}
function onPageLoad()
{dynamicallyPopulate();loadMozillaCSS('11_Custom_Text_Tutorial_files/11_Custom_Text_TutorialMoz.css')
adjustLineHeightIfTooBig('id1');adjustFontSizeIfTooBig('id1');adjustLineHeightIfTooBig('id2');adjustFontSizeIfTooBig('id2');adjustLineHeightIfTooBig('id4');adjustFontSizeIfTooBig('id4');adjustLineHeightIfTooBig('id5');adjustFontSizeIfTooBig('id5');Widget.onload();fixAllIEPNGs('../../../../Media/transparent.gif');BlogFixupPreviousNext();applyEffects()}
function onPageUnload()
{Widget.onunload();}
