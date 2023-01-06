<template>
  <div id="app">
    <GraphViz />
  </div>
</template>

<script>
import GraphViz from "./components/GraphViz.vue";

export default {
  name: "App",
  components: {
    GraphViz,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
