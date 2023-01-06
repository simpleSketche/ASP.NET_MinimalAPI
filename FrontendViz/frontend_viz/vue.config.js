module.exports = {
  devServer:{
    proxy:{
      "^/api":{
        target:'https://localhost:7130/',
        changeOrigin: true
      }
    }
  }
}
console.log("heloooooooooooooo!!!!!!!!!")