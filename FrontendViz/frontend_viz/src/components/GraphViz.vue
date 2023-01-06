<template>
  <div>
    <v-container>
      <v-row justify="space-around">
        <svg width="100%" height="80vh"></svg>
      </v-row>
    </v-container>
  </div>
</template>

<script>
const d3 = require("d3v4");
var graphData = require("../assets/miserable.json");
const axio = require("axios");

export default {
  data: () => {
    return {
      _graphData: {},
    };
  },
  async mounted() {
    await this.GetGraphData();
    console.log(this._graphData);
    this.createGraph();
  },
  methods: {
    async GetGraphData() {
      var graphData = null;
      await axio.get("api/GetGraph").then((res) => {
        graphData = res.data;
        this._graphData = graphData;
      });
    },

    createGraph() {
      var windowWidth = window.innerWidth;
      var windowHeight = window.innerHeight;

      graphData = this._graphData;

      // set the dimensions and margins of the graph
      var margin = { top: 10, right: 30, bottom: 30, left: 40 },
        width = windowWidth - margin.left - margin.right,
        height = windowHeight - margin.top - margin.bottom;

      // append the svg object to the body of the page
      var svg = d3.select("svg");
      svg.width = width;
      svg.height = height;
      var color = d3.scaleOrdinal(d3.schemeCategory20); // scale of an array of colors
      var simulation = d3
        .forceSimulation() // intialize force simulation here
        .force(
          "link",
          d3.forceLink().id(function (d) {
            return d.id;
          }) // assign force to links
        )
        .force("charge", d3.forceManyBody().strength(-1000))
        .force("center", d3.forceCenter(width / 2, height / 2));

      var link = svg
        .append("g")
        .attr("class", "links")
        .selectAll("line")
        .data(graphData.edges)
        .enter()
        .append("line")
        .style("stroke", "gray")
        .style("stroke-width", function (d) {
          return Math.sqrt(d.value);
        });

      var node = svg
        .append("g")
        .attr("class", "nodes")
        .selectAll("g")
        .data(graphData.nodes)
        .enter()
        .append("circle")
        .attr("r", 6)
        .style("fill", function (d) {
          return color(d.group);
        });

      // Create a drag handler and append it to the node object instead
      var drag_handler = d3
        .drag()
        .on("start", dragstarted)
        .on("drag", dragged)
        .on("end", dragended);

      drag_handler(node);

      node.append("title").text(function (d) {
        return d.id;
      });

      simulation.nodes(graphData.nodes).on("tick", ticked);
      simulation.force("link").links(graphData.edges);

      function ticked() {
        link
          .attr("x1", function (d) {
            return d.source.x;
          })
          .attr("y1", function (d) {
            return d.source.y;
          })
          .attr("x2", function (d) {
            return d.target.x;
          })
          .attr("y2", function (d) {
            return d.target.y;
          });
        node.attr("transform", function (d) {
          return "translate(" + d.x + "," + d.y + ")";
        });
      }

      function dragstarted(d) {
        if (!d3.event.active) simulation.alphaTarget(0.3).restart();
        d.fx = d.x;
        d.fy = d.y;
      }

      function dragged(d) {
        d.fx = d3.event.x;
        d.fy = d3.event.y;
      }

      function dragended(d) {
        if (!d3.event.active) simulation.alphaTarget(0);
        d.fx = null;
        d.fy = null;
      }
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
