module.exports = {
  outputDir: "wwwroot/content/dist",
  filenameHashing: false,
  configureWebpack: {
    optimization: {
      splitChunks: false
    },
    resolve: {
      alias: {
        vue$: "vue/dist/vue.esm.js"
      }
    }
  }
};
