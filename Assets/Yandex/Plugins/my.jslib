mergeInto(LibraryManager.library, {

LoadingAPIReady: function(){
console.log("--------Podkluchaem API--------");
ysdk.features.LoadingAPI.ready();
console.log("--------Podkluchili API--------");
},

GameplayAPIStart: function(){
ysdk.features.GameplayAPI.start()
console.log("--------Start API--------");
},

GameplayAPIStop: function(){
ysdk.features.GameplayAPI.stop()
console.log("--------Stop API--------");
}

});