<template>
  <div>
    color:
    <b-form-input
      id="colorRange"
      v-model="hue"
      type="range"
      min="0"
      max="360"
    ></b-form-input>
  </div>
</template>

<script>
export default {
  computed: {
    hue: {
      get() {
        return this.$store.getters.color;
      },
      set(value) {
        this.$store.commit("setColor", value);
      }
    }
  }
};
</script>

<style lang="scss">
#colorRange {
  width: 20vw;
  margin-left: -5vw;
}
</style>
