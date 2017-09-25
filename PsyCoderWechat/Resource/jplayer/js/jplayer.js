!function(t,s){jPlayerPlaylist=function(s,i,e){var l=this;this.current=0,this.loop=!1,this.shuffled=!1,this.removing=!1,this.cssSelector=t.extend({},this._cssSelector,s),this.options=t.extend(!0,{keyBindings:{next:{key:39,fn:function(){l.next()}},previous:{key:37,fn:function(){l.previous()}}}},this._options,e),this.playlist=[],this.original=[],this._initPlaylist(i),this.cssSelector.title=this.cssSelector.cssSelectorAncestor+" .jp-title",this.cssSelector.playlist=this.cssSelector.cssSelectorAncestor+" .jp-playlist",this.cssSelector.next=this.cssSelector.cssSelectorAncestor+" .jp-next",this.cssSelector.previous=this.cssSelector.cssSelectorAncestor+" .jp-previous",this.cssSelector.shuffle=this.cssSelector.cssSelectorAncestor+" .jp-shuffle",this.cssSelector.shuffleOff=this.cssSelector.cssSelectorAncestor+" .jp-shuffle-off",this.options.cssSelectorAncestor=this.cssSelector.cssSelectorAncestor,this.options.repeat=function(t){l.loop=t.jPlayer.options.loop},t(this.cssSelector.jPlayer).bind(t.jPlayer.event.ready,function(){l._init()}),t(this.cssSelector.jPlayer).bind(t.jPlayer.event.ended,function(){l.next()}),t(this.cssSelector.jPlayer).bind(t.jPlayer.event.play,function(){t(this).jPlayer("pauseOthers")}),t(this.cssSelector.jPlayer).bind(t.jPlayer.event.resize,function(s){s.jPlayer.options.fullScreen?t(l.cssSelector.title).show():t(l.cssSelector.title).hide()}),t(this.cssSelector.previous).click(function(){return l.previous(),t(this).blur(),!1}),t(this.cssSelector.next).click(function(){return l.next(),t(this).blur(),!1}),t(this.cssSelector.shuffle).click(function(){return l.shuffle(!0),!1}),t(this.cssSelector.shuffleOff).click(function(){return l.shuffle(!1),!1}).hide(),this.options.fullScreen||t(this.cssSelector.title).hide(),t(this.cssSelector.playlist+" ul").empty(),this._createItemHandlers(),t(this.cssSelector.jPlayer).jPlayer(this.options)},jPlayerPlaylist.prototype={_cssSelector:{jPlayer:"#jquery_jplayer_1",cssSelectorAncestor:"#jp_container_1"},_options:{playlistOptions:{autoPlay:!1,loopOnPrevious:!1,shuffleOnLoop:!0,enableRemoveControls:!1,displayTime:"slow",addTime:"fast",removeTime:"fast",shuffleTime:"slow",itemClass:"jp-playlist-item",freeGroupClass:"jp-free-media",freeItemClass:"jp-playlist-item-free",removeItemClass:"jp-playlist-item-remove"}},option:function(t,i){if(i===s)return this.options.playlistOptions[t];switch(this.options.playlistOptions[t]=i,t){case"enableRemoveControls":this._updateControls();break;case"itemClass":case"freeGroupClass":case"freeItemClass":case"removeItemClass":this._refresh(!0),this._createItemHandlers()}return this},_init:function(){var t=this;this._refresh(function(){t.options.playlistOptions.autoPlay?t.play(t.current):t.select(t.current)})},_initPlaylist:function(s){this.current=0,this.shuffled=!1,this.removing=!1,this.original=t.extend(!0,[],s),this._originalPlaylist()},_originalPlaylist:function(){var s=this;this.playlist=[],t.each(this.original,function(t){s.playlist[t]=s.original[t]})},_refresh:function(s){var i=this;if(s&&!t.isFunction(s))t(this.cssSelector.playlist+" ul").empty(),t.each(this.playlist,function(s){t(i.cssSelector.playlist+" ul").append(i._createListItem(i.playlist[s]))}),this._updateControls();else{var e=t(this.cssSelector.playlist+" ul").children().length?this.options.playlistOptions.displayTime:0;t(this.cssSelector.playlist+" ul").slideUp(e,function(){var e=t(this);t(this).empty(),t.each(i.playlist,function(t){e.append(i._createListItem(i.playlist[t]))}),i._updateControls(),t.isFunction(s)&&s(),i.playlist.length?t(this).slideDown(i.options.playlistOptions.displayTime):t(this).show()})}},_createListItem:function(s){var i=this,e="<li><div>";if(e+="<a href='javascript:;' class='"+this.options.playlistOptions.removeItemClass+"'>&times;</a>",s.free){var l=!0;e+="<span class='"+this.options.playlistOptions.freeGroupClass+"'>(",t.each(s,function(s,o){t.jPlayer.prototype.format[s]&&(l?l=!1:e+=" | ",e+="<a class='"+i.options.playlistOptions.freeItemClass+"' href='"+o+"' tabindex='1'>"+s+"</a>")}),e+=")</span>"}return e+="<a href='javascript:;' class='"+this.options.playlistOptions.itemClass+"' tabindex='1'>"+s.title+(s.artist?" <span class='jp-artist'>by "+s.artist+"</span>":"")+"</a>",e+="</div></li>"},_createItemHandlers:function(){var s=this;t(this.cssSelector.playlist).off("click","a."+this.options.playlistOptions.itemClass).on("click","a."+this.options.playlistOptions.itemClass,function(){var i=t(this).parent().parent().index();return s.current!==i?s.play(i):t(s.cssSelector.jPlayer).jPlayer("play"),t(this).blur(),!1}),t(this.cssSelector.playlist).off("click","a."+this.options.playlistOptions.freeItemClass).on("click","a."+this.options.playlistOptions.freeItemClass,function(){return t(this).parent().parent().find("."+s.options.playlistOptions.itemClass).click(),t(this).blur(),!1}),t(this.cssSelector.playlist).off("click","a."+this.options.playlistOptions.removeItemClass).on("click","a."+this.options.playlistOptions.removeItemClass,function(){var i=t(this).parent().parent().index();return s.remove(i),t(this).blur(),!1})},_updateControls:function(){this.options.playlistOptions.enableRemoveControls?t(this.cssSelector.playlist+" ."+this.options.playlistOptions.removeItemClass).show():t(this.cssSelector.playlist+" ."+this.options.playlistOptions.removeItemClass).hide(),this.shuffled?(t(this.cssSelector.shuffleOff).show(),t(this.cssSelector.shuffle).hide()):(t(this.cssSelector.shuffleOff).hide(),t(this.cssSelector.shuffle).show())},_highlight:function(i){this.playlist.length&&i!==s&&(t(this.cssSelector.playlist+" .jp-playlist-current").removeClass("jp-playlist-current"),t(this.cssSelector.playlist+" li:nth-child("+(i+1)+")").addClass("jp-playlist-current").find(".jp-playlist-item").addClass("jp-playlist-current"),t(this.cssSelector.title+" li").html(this.playlist[i].title+(this.playlist[i].artist?" <span class='jp-artist'>by "+this.playlist[i].artist+"</span>":"")))},setPlaylist:function(t){this._initPlaylist(t),this._init()},add:function(s,i){t(this.cssSelector.playlist+" ul").append(this._createListItem(s)).find("li:last-child").hide().slideDown(this.options.playlistOptions.addTime),this._updateControls(),this.original.push(s),this.playlist.push(s),i?this.play(this.playlist.length-1):1===this.original.length&&this.select(0)},remove:function(i){var e=this;return i===s?(this._initPlaylist([]),this._refresh(function(){t(e.cssSelector.jPlayer).jPlayer("clearMedia")}),!0):this.removing?!1:(i=0>i?e.original.length+i:i,i>=0&&i<this.playlist.length&&(this.removing=!0,t(this.cssSelector.playlist+" li:nth-child("+(i+1)+")").slideUp(this.options.playlistOptions.removeTime,function(){if(t(this).remove(),e.shuffled){var s=e.playlist[i];t.each(e.original,function(t){return e.original[t]===s?(e.original.splice(t,1),!1):void 0}),e.playlist.splice(i,1)}else e.original.splice(i,1),e.playlist.splice(i,1);e.original.length?i===e.current?(e.current=i<e.original.length?e.current:e.original.length-1,e.select(e.current)):i<e.current&&e.current--:(t(e.cssSelector.jPlayer).jPlayer("clearMedia"),e.current=0,e.shuffled=!1,e._updateControls()),e.removing=!1})),!0)},select:function(s){s=0>s?this.original.length+s:s,s>=0&&s<this.playlist.length?(this.current=s,this._highlight(s),t(this.cssSelector.jPlayer).jPlayer("setMedia",this.playlist[this.current])):this.current=0},play:function(i){i=0>i?this.original.length+i:i,i>=0&&i<this.playlist.length?this.playlist.length&&(this.select(i),t(this.cssSelector.jPlayer).jPlayer("play")):i===s&&t(this.cssSelector.jPlayer).jPlayer("play")},pause:function(){t(this.cssSelector.jPlayer).jPlayer("pause")},next:function(){var t=this.current+1<this.playlist.length?this.current+1:0;this.loop?0===t&&this.shuffled&&this.options.playlistOptions.shuffleOnLoop&&this.playlist.length>1?this.shuffle(!0,!0):this.play(t):t>0&&this.play(t)},previous:function(){var t=this.current-1>=0?this.current-1:this.playlist.length-1;(this.loop&&this.options.playlistOptions.loopOnPrevious||t<this.playlist.length-1)&&this.play(t)},shuffle:function(i,e){var l=this;i===s&&(i=!this.shuffled),(i||i!==this.shuffled)&&t(this.cssSelector.playlist+" ul").slideUp(this.options.playlistOptions.shuffleTime,function(){l.shuffled=i,i?l.playlist.sort(function(){return.5-Math.random()}):l._originalPlaylist(),l._refresh(!0),e||!t(l.cssSelector.jPlayer).data("jPlayer").status.paused?l.play(0):l.select(0),t(this).slideDown(l.options.playlistOptions.shuffleTime)})}}}(jQuery);