$(document).ready(function () {


    var playlist = [
     {
         title: "大王带我来巡山",
         artist: "",
         mp3: "http://sky20100.oss-cn-beijing.aliyuncs.com/audios/dawagnjiaowolaixunshan.mp3?Expires=1505356777&OSSAccessKeyId=TMP.AQHPdPWh6_okaUjDsa8haVe7q7S50MUMTty7OrarEF3z1x24nXVRXcOyZUc-ADAtAhQrxKqec5aAE4nzeyBQ2zYYORF-QQIVANJnoecU1Y67kLTA5j8ZJq5BPNsE&Signature=kihqPIZlNV1TcDGKKn23uHbn24M%3D",
         poster: "https://img.alicdn.com/imgextra/i2/645383876/TB2rB1AXDAKh1JjSZFDXXbKlFXa_!!645383876.jpg"
     },

     {
         title: "圣诞结",
         artist: "",
         mp3: "http://mxlogo.com/fmbox/mp3/103018102.mp3",
         /*下面是海报*/
         poster: "https://img.alicdn.com/imgextra/i1/645383876/TB2cl5nXDAKh1JjSZFDXXbKlFXa_!!645383876.jpg"
     },
  //	
  //	{
  //      title:"岚",
  //      artist:"",
  //      mp3:"http://www.mxlogo.com/fmbox/mp3/3.mp3",
  //      poster: "http://www.mxlogo.com/fmbox/img/lan.jpg"
  //    },
      {
          title: "瑜伽",
          artist: "",
          mp3: "http://mxlogo.com/fmbox/mp3/1030108103.mp3",
          poster: "https://img.alicdn.com/imgextra/i4/645383876/TB23_dXuhtmpuFjSZFqXXbHFpXa_!!645383876.jpg"
      },

      {
          title: "至少还有你",
          artist: "",
          mp3: "http://tool.4vtk.com/music/music.php?hash=e3e41a40c3c83c96b4ff36a408f5a345",
          poster: "https://img.alicdn.com/imgextra/i2/645383876/TB2AK8Gq88lpuFjSspaXXXJKpXa_!!645383876.jpg"
      },

      {
          title: "Party Rock Anthem",
          artist: "",
          mp3: "http://ws.stream.qqmusic.qq.com/9065951.m4a?fromtag=46",
          poster: "https://img.alicdn.com/imgextra/i1/645383876/TB2jU4idCB0XKJjSZFsXXaxfpXa_!!645383876.jpg"
      },


    ];

    /*	{
          title:"Cro Magnon Man",
          artist:"The Stark Palace",
          mp3:"http://jq22.qiniudn.com/i2.mp3",
          poster: "http://33.media.tumblr.com/bf9dc125a47dcca91ce5b3575bc3ba92/tumblr_nbmb3j8nU51sq3g2zo1_500.png"
        },
        这个可以自己随便加了  嘎嘎嘎嘎嘎啊噶
        /mxlogo/web/fmbox/mp3/
        */





    var cssSelector = {
        jPlayer: "#jquery_jplayer",
        cssSelectorAncestor: ".music-player"
    };

    var options = {
        playlistOptions: {
            autoPlay: true,
        },
        swfPath: "http://cdnjs.cloudflare.com/ajax/libs/jplayer/2.6.4/jquery.jplayer/Jplayer.swf",
        supplied: "ogv, m4v, oga, mp3"
    };
    var myPlaylist = new jPlayerPlaylist(cssSelector, playlist, options);
    myPlaylist.play(2);

});