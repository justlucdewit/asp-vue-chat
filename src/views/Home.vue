<template>
  <div class="home">
    <div id="mainSection">
      <NameField class="nameField" />
      <ColorField class="nameField" />
      <ChannelField class="nameField" />
      <Feed id="feedField" />
    </div>
    <TypingBar v-on:onMessage="newMessage" />
  </div>
</template>

<script>
// components
import TypingBar from "@/components/TypingBar.vue";
import Feed from "@/components/Feed.vue";
import NameField from "@/components/NameField.vue";
import ColorField from "@/components/ColorField.vue";
import ChannelField from "@/components/ChannelField.vue";

// libaries
import axios from "axios";

export default {
  name: "Home",

  mounted: function() {
    window.setInterval(() => {
      axios.get(`api/getServer/${this.$store.getters.server}`).then(res => {
        this.$store.commit("setMessages", res.data);
      });
    }, 500);
  },

  methods: {
    newMessage: function(message) {
      // store message in store
      this.$store.commit("addMessage", {
        message: message,
        author: this.$store.getters.name,
        color: this.$store.getters.color,
        server: this.$store.getters.server,
        date: ""
      });

      // send message to server
      console.log(
        `/api/sendMessage/${message}/${this.$store.getters.name}/${this.$store.getters.color}/${this.$store.getters.server}`
      );
      axios.get(
        `/api/sendMessage/${message}/${this.$store.getters.name}/${this.$store.getters.color}/${this.$store.getters.server}`
      );

      // scroll to bottom of feed
      setTimeout(
        () =>
          (document.getElementById(
            "feedField"
          ).scrollTop = document.getElementById("feedField").scrollHeight),
        200
      );
    }
  },

  components: {
    TypingBar,
    Feed,
    NameField,
    ColorField,
    ChannelField
  }
};
</script>

<style lang="scss">
#mainSection {
  .nameField {
    float: left;
    display: inline;
    width: 10vw;
    margin-left: 18vw;
  }

  #feedField {
    width: 80vw;
    float: left;
    border: 1px solid #ced4da;
    height: 60vh;
    margin-top: 10px;
    margin-left: 10vw;
    border-radius: 0.25rem;
    text-align: left;
    padding-left: 10px;
    overflow: scroll;
  }
}
</style>
