using EZCode;
using System.Windows.Forms;

namespace Paddle_Game {
    internal static class Program {
        [STAThread] static void Main() {
            ApplicationConfiguration.Initialize();
            EzCode ez = new EzCode();
            string code = @"#current file C:\Users\jlham\OneDrive\Documents\GitHub\EZCode-Projects\Paddle_Game\Title.ezcode

//Project Properties
#project properties : name:Paddle Game, icon:C:\Users\jlham\OneDrive\Documents\GitHub\EZCode-Projects\Paddle_Game\Images\icon.ico, fileinerror:False, showbuild:False, window:True, isvisual:False, clearconsole:True, debug:False, closeonend:True

//Title.ezcode
method Entry 
    window main new : text:Paddle Game, icon:~/Images/icon.ico, bg:[60;50;50], type:none, state:maximized
    event main close Quit
    main open
    global var ball_speed 12
    global var player_speed 18
    global var Row 4
    global var Coulumn 8
    
    GetSettings

    global var width main:width
    global var height main:height
    sound BGMusic new ~/Music/8bit-music-From-Pixaby.mp3
    sound BGMusic playloop
    
    Title
endmethod

method Title
    // Title Label
    var tpx (width / 2 - 300)
    var tpy (height / 2 - 450)
    global label TitleLabel text:Paddle Game, align:middlecenter, bg:[60;50;50], fc:[220;220;220], font:[Impact;75;Regular], ->
        x:tpx, y:tpy, w:600, h:300, auto:false
    main display TitleLabel
    
    // About Label
    var aboutLabelText Paddle Game is a rendition of the original Atari Game\c Breakout\c now made with EZCode. Using EZCode\c ->
    this game comes to life in a new way and shows off some of the capabilities of EZCode. Use the Left ->
        and Right arrow keys\c or A and D\c to move. Press Esc to exit. You win once you have destroyed all of ->
        the blocks. Good luck\e\nCreated by JBros Development\c SFX and Music from pixaby.com
    var apx (width / 2 - 400)
    var apy (height / 2 - 200)
    global label AboutLabel text:'aboutLabelText', align:topcenter, bg:[60;50;50], fc:[220;220;220], font:[Impact;20;Regular], ->
        x:apx, y:apy, w:800, h:250, auto:false
    main display AboutLabel
    
    // Start Button
    var strtposx (width / 2 - 250)
    var strtposy (height / 2 - 100 + 160)
    global button Start t:Play!, w:500, h:200, x:strtposx, y:strtposy, bg:[20;50;100], fc:[220;220;220], font:[Impact;25;Bold]
    event Start click Play
    main display Start
    
    // Settings Button
    var stgposx (width / 2 - 250)
    var stgposy (height / 2 - 50 + 315)
    global button Settings t:Settings, w:500, h:75, x:stgposx, y:stgposy, bg:[20;50;100], fc:[220;220;220], font:[Impact;25;Bold]
    event Settings click ShowSettings
    main display Settings
    
    // Quit Button
    var qbposx (width / 2 - 250)
    var qbposy (height / 2 - 50 + 395)
    global button QuitButton t:Quit, w:500, h:75, x:qbposx, y:qbposy, bg:[20;50;100], fc:[220;220;220], font:[Impact;25;Bold]
    event QuitButton click Quit
    main display QuitButton
    
    // Layer
    bringto front TitleLabel
    bringto front AboutLabel
    bringto front Settings
    bringto front QuitButton
    bringto front Start
    
    // Game Loop
    loop true {
        await 100
        var escape : input key escape
        var shift : input key shiftkey
        if shift and escape : stop all
    }
endmethod

method Play
    sound stopall
    destroy Start
    destroy Settings
    destroy TitleLabel
    destroy AboutLabel
    destroy QuitButton
    Main
endmethod

method Display : titlet:\!, infot:\!
    // Won Label
    var x1 (width / 2 - 300)
    var y1 (height / 2 - 450)
    label WonLabel text:'titlet', align:middlecenter, bg:[60;50;50], fc:[220;220;220], font:[Impact;75;Regular], ->
        x:x1, y:y1, w:600, h:300, auto:false
    main display WonLabel
    
    // Exit Button
    var x2 (width / 2 - 200)
    var y2 (height / 2 - 50 + 315)
    button Exit t:Exit, w:400, h:75, x:x2, y:y2, bg:[20;50;100], fc:[220;220;220], font:[Impact;25;Bold]
    event Exit click Restart
    main display Exit
    
    // Info Label
    var x3 (width / 2 - 400)
    var y3 (height / 2 - 225)
    label InfoLabel text:'infot', align:topcenter, bg:[60;50;50], fc:[220;220;220], font:[Impact;20;Regular], ->
        x:x3, y:y3, w:800, h:250, auto:false
    main display InfoLabel
endmethod

method End : done:true
    Clear_Game
    if done : | Display : YOU WON, Congratulations!
    else : | Display : YOU LOST, Want to try again?
endmethod

method Restart
    sound stopall
    stop restart
endmethod

method Quit
    sound stopall
    stop all
endmethod

//CreateBlocks.ezcode
#current file C:\Users\jlham\OneDrive\Documents\GitHub\EZCode-Projects\Paddle_Game\CreateBlocks.ezcode
method CreateBlocks : rows:4, coulumns:8
    var padding 20
    var coulumnEven (coulumns - 1)
    var block_h 100
    var block_dis_h (block_h + padding)
    var wbefore (width / coulumns)
    var block_w (wbefore - padding)
    var halfpad (padding / 2)
    
    list bx new
    list by new
    list bw new
    list bh new
    
    var i 0
    loop rows {
        i + 1
        var ybefore (i * block_dis_h + padding)
        var block_y (ybefore + padding - block_h)

        var even i
        IsEven : even
        if even : {
            var j 0
            loop coulumns {
                j + 1
                var xbefore (width / coulumns)
                var colxbef (xbefore * j)
                var block_x (colxbef - block_w - halfpad)
                bx add 'block_x'
                by add 'block_y'
                bw add 'block_w'
                bh add 'block_h'
            }
        }
        else : {
            var j 0
            loop coulumnEven {
                j + 1
                var xbefore (width / coulumns)
                var colxbef (xbefore * j)
                var blockoffset (block_w / 2)
                var block_x (colxbef - block_w - halfpad + blockoffset)
                bx add 'block_x'
                by add 'block_y'
                bw add 'block_w'
                bh add 'block_h'
            }
        }
    }
    i = 0
    loop bx:length {
        var blx bx:i
        var bly by:i
        var blw bw:i
        var blh bh:i
        
        instance shape name:b'i', x:blx, y:bly, w:blw, h:blh
        main display b'i'
        blocks add : b'i'
        
        i + 1
    }
endmethod

method IsEven : num:1
{
    var a (num / 2)
    var b (a * 2)
    num =  (num - b)
}
endmethod


//Main.ezcode
#current file C:\Users\jlham\OneDrive\Documents\GitHub\EZCode-Projects\Paddle_Game\Main.ezcode
method Main
    sound BlockHit new ~/Music/block-hit-From-Pixaby.mp3
    sound PaddleHit new ~/Music/retro-bump-From-Pixaby.mp3

    global var isrunning true
    global var size_w 200 | var dif_w (size_w / 2)
    global var size_h 30
    
    global var pos_x (width / 2 - dif_w)
    global var pos_y (height - 100)
    var _rando system:random:-50:50
    global var ball_r 50 | var ball_dif (ball_r / 2)
    global var ball_x (width / 2 - ball_dif + _rando)
    global var ball_y (pos_y - size_h - ball_r)
    var bally_look (height / 1.7)
    
    global shape player x:pos_x, y:pos_y, w:size_w, h:size_h, bg:[75;75;250]
    global shape ball x:ball_x, y:ball_y, poly:20, bg:[255;255;255]

    main display player
    main display ball

    var rand_dir system:random:0:10
    if rand_dir > 5 : rand_dir = -1
    else : rand_dir = 1
    global var dir_x rand_dir
    global var dir_y 1

    global group blocks new
    CreateBlocks : Row, Coulumn
    blocks change 0 bg:[25;75;25]
    bringto front ball
    bringto back player
    await 500
    var tick 10

    loop isrunning {
        await tick
        
        // player movement
        var movement 0
        var left : input key left | if ! left : | left : input key a
        var right : input key right | if ! right : | right : input key d
        if left & ! right : movement = -1
        if ! left & right : movement = 1
        if pos_x < -10 : pos_x = 0
        var left_collision (width - size_w - 10)
        if pos_x > left_collision : pos_x = (width - size_w)
        pos_x + (movement * player_speed)
        player x:pos_x
        
        // ball movement
        var left_ball_col (width - ball_r - 10)
        
        if ball_x < -10 : dir_x = (- dir_x)
        if ball_x > left_ball_col : dir_x = -1
        if ball_y < -10 : dir_y = (- dir_y)
        if ball_y > height : {
            isrunning = false
            player bg:[60;50;50]
            End : 0
        }
        var bpcol : intersects ball player
        if bpcol : {
            sound PaddleHit stop
            sound PaddleHit play
            if movement = 0 : movement = dir_x
            dir_y = -1
            dir_x = movement
            
            //var ymov -1
            //var valrand system:random:2:5
            //if valrand = 2 : { | // ymov = -2 | // if movement <= -1 : movement = -1 | //  else : movement = 1 | // }
            //if valrand = 3 : { | // ymov = -1.5 | // if movement <= -1 : movement = -1.5 | // else : movement = 1.5 | // }
            //if valrand < 3 : { | // ymov = -1 | // if movement <= -1 : movement = -2 | //  else : movement = 2 | // }
        }
        ball_x + (dir_x * ball_speed)
        ball_y + (dir_y * ball_speed)
        ball x:ball_x, y:ball_y
        
        //ball collision
        if ball_y < bally_look : {
            group destroys new
            tick = 3
            var i 0
            loop blocks:length {
                shape ins
                ins = blocks:i # suppress error
                var blockinter : intersects ins ball
                if blockinter : {
                    sound BlockHit stop
                    sound BlockHit play
                    destroys add : blocks:i
                    blocks remove blocks:i
                    var _x ins:x
                    var _y ins:y
                    var _w ins:w
                    var _h ins:h
                    Collision : _x, _y, _w, _h
                }
                destroy ins
                i + 1
            }
            destroys destroyall
        }
        else : tick = 10
        
        //winning
        var blockslef blocks:length 
        if blockslef = 0 : {
            isrunning = false
            player bg:[60;50;50]
            End : 1
        }

        var escape : input key escape
        var shift : input key shiftkey
        if escape : {
            if shift : stop all
            Clear_Game
            isrunning = false
            stop restart
        }
    }
endmethod

method Clear_Game
    destroy player # suppress error
    destroy ball # suppress error
    blocks destroyall # suppress error
endmethod

method Collision : bx:0, by:0, bw:0, bh:0
    var pad 5
    var ball_end_x (ball_x + ball_r - pad)
    var ball_end_y (ball_y + ball_r - pad)
    var block_end_x (bx + bw - pad)
    var block_end_y (by + bh - pad)
    //var posx dir_x | // if dir_x <= -1 : posx = (- dir_x)
    //var negx dir_x | // if dir_x >= 1 : negx = (- dir_x)
    //var posy dir_y | // if dir_y <= -1 : posy = (- dir_y)
    //var negy dir_y | // if dir_y >= 1 : negy = (- dir_y)
    if ball_y > block_end_y : dir_y = 1
    if ball_end_y < by : dir_y = -1
    if ball_x > block_end_x : dir_x = 1
    if ball_end_x < bx : dir_x = -1
endmethod

//Settings.ezcode
#current file C:\Users\jlham\OneDrive\Documents\GitHub\EZCode-Projects\Paddle_Game\Settings.ezcode
method ShowSettings
    // Back Panel
    global shape Panel x:(width / 2 - 400), y:(height / 2 - 450), w:800, h:900, bg:[20;20;40]
    main display Panel
    
    // SettingsLabel
    global label SettingsLabel x:(width / 2 - 400), y:(height / 2 - 425), w:800, h:200, bg:[20;20;40], fc:[220;220;220], -> 
        font:[Impact;65;Regular], align:middlecenter, text:Settings, auto:false
    main display SettingsLabel
    
    // Back
    global button Back text:Back, w:500, h:100, x:(width / 2 - 250), y:(height / 2 + 275), bg:[20;50;100], fc:[220;220;220], font:[Impact;25;Bold]
    event Back click Restart
    main display Back
    
    // PlayerSpeedLabel
    global label PlayerSpeedLabel t:Player Speed, auto:false, align:middleleft, h:50, w:300, x:(width / 2 - 350), y:(height / 2 - 200), ->
        bg:[20;20;40], fc:[220;220;220], font:[Impact;25;Regular]
    main display PlayerSpeedLabel
    
    // PlayerSpeedTB
    global textbox PlayerSpeedTB t:'player_speed', auto:false, h:50, w:300, x:(width / 2 + 50), y:(height / 2 - 200), ->
        bg:[220;220;220], fc:[40;40;80], font:[Impact;25;Regular]
    event PlayerSpeedTB text SettingsChanged
    main display PlayerSpeedTB
    
    // BallSpeedLabel
    global label BallSpeedLabel t:Ball Speed, auto:false, align:middleleft, h:50, w:300, x:(width / 2 - 350), y:(height / 2 - 125), ->
        bg:[20;20;40], fc:[220;220;220], font:[Impact;25;Regular]
    main display BallSpeedLabel
    
    // BallSpeedTB
    global textbox BallSpeedTB t:'ball_speed', auto:false, h:50, w:300, x:(width / 2 + 50), y:(height / 2 - 125), ->
        bg:[220;220;220], fc:[40;40;80], font:[Impact;25;Regular]
    event BallSpeedTB text SettingsChanged
    main display BallSpeedTB
    
    // CoulumnLabel
    global label CoulumnLabel t:Coulumns, auto:false, align:middleleft, h:50, w:300, x:(width / 2 - 350), y:(height / 2 - 50), ->
        bg:[20;20;40], fc:[220;220;220], font:[Impact;25;Regular]
    main display CoulumnLabel
    
    // CoulumnTB
    global textbox CoulumnTB t:'Coulumn', auto:false, h:50, w:300, x:(width / 2 + 50), y:(height / 2 - 50), ->
        bg:[220;220;220], fc:[40;40;80], font:[Impact;25;Regular]
    event CoulumnTB text SettingsChanged
    main display CoulumnTB
    
    // RowLabel
    //global label RowLabel t:Rows, auto:false, align:middleleft, h:50, w:300, x:(width / 2 - 350), y:(height / 2 + 25), ->
    //    bg:[20;20;40], fc:[220;220;220], font:[Impact;25;Regular]
    //main display RowLabel
    
    // RowTB
    //global textbox RowTB t:'Row', auto:false, h:50, w:300, x:(width / 2 + 50), y:(height / 2 + 25), ->
    //    bg:[220;220;220], fc:[40;40;80], font:[Impact;25;Regular]
    //event RowTB text SettingsChanged
    //main display RowTB
endmethod

method SettingsChanged
    var newpspeed PlayerSpeedTB:text
    var newbspeed BallSpeedTB:text
    var newcol CoulumnTB:text
    //var newrow RowTB:text
    var pisnumber system:isnumber:'newpspeed'
    var nisnumber system:isnumber:'newbspeed'
    var cisnumber system:isnumber:'newcol'
    //var risnumber system:isnumber:'newrow'
    
    if ! pisnumber : messagebox Error Player\_Speed\_Needs\_to\_be\_a\_Number
    else : {
        player_speed = newpspeed
        file write 'newpspeed' ~/Save/PlayerSpeed.txt
    }
    if ! nisnumber : messagebox Error Ball\_Speed\_Needs\_to\_be\_a\_Number
    else : {
        ball_speed = newbspeed
        file write 'newbspeed' ~/Save/BallSpeed.txt
    }
    if ! cisnumber : messagebox Error Coulumns\_Needs\_to\_be\_a\_Number
    else : {
        Coulumn = newcol
        file write 'newcol' ~/Save/Coulumns.txt
    }
    //if ! risnumber : messagebox Error Rows\_Needs\_to\_be\_a\_Number
    //else : {
    //    Row = newrow
    //    file write 'newrow' ~/Save/Rows.txt
    //}
endmethod

method GetSettings
    var pspeed : file read ~/Save/PlayerSpeed.txt
    var bspeed : file read ~/Save/BallSpeed.txt
    var col : file read ~/Save/Coulumns.txt
    //var row : file read ~/Save/Rows.txt
    var pisnumber system:isnumber:'pspeed'
    var nisnumber system:isnumber:'bspeed'
    var cisnumber system:isnumber:'col'
    //var risnumber system:isnumber:'row'
    
    if pisnumber : {
        player_speed = pspeed
    }
    if nisnumber : {
        ball_speed = bspeed
    }
    if cisnumber : {
        Coulumn = col
    }
    //if risnumber : {
    //    Row = row
    //}
endmethod
";
            ez.Code = code;
            EZProj proj = new EZProj(ez);
            var player = new EZCode.EZPlayer.Player(proj);
            Application.Run(player);
        }
    }
}